using System;
using System.Linq;
using ResourceBasedAuthenticationTest.Models;

namespace ResourceBasedAuthenticationTest
{
    public static class RbaDbContextExtensions
    {
        public static IQueryable<User> GetDepartmentUsers(this RbaDbContext context, int departmentId)
            => context.FromExpression(() => GetDepartmentUsers(departmentId));

        public static IQueryable<User> GetDepartmentUsers(int _department_id)
        {
            throw new InvalidOperationException();
        }
    }
}