using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLib.Models
{
    [Table(name:"user", Schema ="auth")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int Id { get; set; }
        [Column("email")]
        [Required]
        public required string Email { get; set; }
        [Column("password")]
        public byte[] Password { get; set; } = new byte[] { };
        public byte[] Salt { get; set; } = new byte[] { };
        public Guid RoleId { get; set; }
    }
}
