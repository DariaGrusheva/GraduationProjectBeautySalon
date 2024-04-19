using BeautySalon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.Auth.Models
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
        [Column("salt")]
        public byte[] Salt { get; set; } = new byte[] { };
        [ForeignKey(nameof(Role))]
        [Column("role_id")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [ForeignKey(nameof(Employee))]
        [Column("employee_id")]
        public int? EmployeeId { get; set; }
        Employee? Employee { get; set; }
        [NotMapped]
        public string? PasswordString { get; set; }
    }
}
