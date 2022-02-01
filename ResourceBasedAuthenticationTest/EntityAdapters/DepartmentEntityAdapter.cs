using System.Linq;
using ResourceBasedAuthenticationTest.Models;

namespace ResourceBasedAuthenticationTest.EntityAdapters
{
    public class DepartmentEntityAdapter
    {
        private readonly RbaDbContext _db;
        private readonly int _userId;

        public DepartmentEntityAdapter(RbaDbContext db, int userId)
        {
            _db = db;
            _userId = userId;
        }
    }
}