using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceBasedAuthenticationTest.Models
{
    public class DepartmentUser : BaseEntity
    {
        [Column("department_id")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}