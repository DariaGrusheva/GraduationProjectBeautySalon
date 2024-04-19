using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Auth.Models
{
    [Table(name:"role", Schema ="auth")]
    public class Role
    {
        [Key]
        [Column("role_id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
