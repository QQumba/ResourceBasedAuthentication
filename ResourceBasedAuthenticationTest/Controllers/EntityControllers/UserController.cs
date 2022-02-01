using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceBasedAuthenticationTest.Models;
using ResourceBasedAuthenticationTest.ViewModels;
using Z.EntityFramework.Plus;
using Task = System.Threading.Tasks.Task;

namespace ResourceBasedAuthenticationTest.Controllers.EntityControllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly RbaDbContext _db;

        public UserController(RbaDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            // todo: replace by paginated read
            var users = await _db.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{departmentId:int}")]
        public async Task<ActionResult<IEnumerable<User>>> GetDepartmentUsers([FromRoute] int departmentId)
        {
            var users = await _db.DepartmentUsers.Where(du => du.Department.Id == departmentId)
                .Include(du => du.Department)
                .Select(du => du.User)
                .ToListAsync();

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserCreateViewModel user)
        {
            var createdUser = _db.Users.Add(user.Adapt<User>());
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateUser), createdUser.Entity);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            await _db.Users.Where(u => u.Id == id).DeleteAsync();
            return NoContent();
        }
    }
}