using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceBasedAuthenticationTest.Models;
using ResourceBasedAuthenticationTest.ViewModels;

namespace ResourceBasedAuthenticationTest.Controllers.EntityControllers
{
    [ApiController]
    [Route("api/department")]
    public class DepartmentController : ControllerBase
    {
        private readonly RbaDbContext _db;

        public DepartmentController(RbaDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
        {
            var departments = await _db.Departments.ToListAsync();
            return Ok(departments);
        }

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<IEnumerable<Department>>> GetUserDepartments([FromRoute] int userId)
        {
            var departments = await _db.DepartmentUsers.Where(du => du.User.Id == userId)
                .Include(du => du.Department)
                .Select(du => du.Department)
                .ToListAsync();

            return Ok(departments);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Department>>> CreateDepartment(
            [FromBody] DepartmentCreateViewModel department)
        {
            var createdDepartment = await _db.Departments.AddAsync(department.Adapt<Department>());
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateDepartment), createdDepartment.Entity);
        }

        [HttpPost("{departmentId:int}")]
        public async Task<ActionResult> AddUser([FromRoute] int departmentId, [FromBody] int userId)
        {
            var department = await _db.Departments.FindAsync(departmentId);
            if (department is null)
            {
                return NotFound($"Department with given id: {departmentId}, not found");
            }

            var user = await _db.Users.FindAsync(userId);
            if (user is null)
            {
                return NotFound($"User with given id: {userId}, not found");
            }

            _db.Add(new DepartmentUser
            {
                Department = department,
                User = user
            });
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}