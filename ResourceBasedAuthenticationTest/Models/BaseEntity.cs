using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceBasedAuthenticationTest.Models
{
    public abstract class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}