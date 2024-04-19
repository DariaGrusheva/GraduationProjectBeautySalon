using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models
{
    [Table(name:"client", Schema = "public")]
    public class Client
    {
        [Column("client_id")]
        [Key]
        public int ClientId { get; set; }

        [Column("firstname")]
        [Required]
        [StringLength(50, ErrorMessage = "Длина поля не должна превышать 50 символов")]
        public string ClientName { get; set;}

        [Column("phone_number")]
        [Required]
        [StringLength(30, ErrorMessage = "Длина поля не должна превышать 30 символов")]
        public string PhoneNumber { get; set; }

        [Column("email")]
        [StringLength(100, ErrorMessage = "Длина поля не должна превышать 100 символов")]
        public string? Email { get; set; }

        [Column("note")]
        [StringLength(200, ErrorMessage = "Длина поля не должна превышать 200 символов")]
        public string? Note { get; set; }

        public ICollection<Record> Records { get; set; } = new List<Record>();
    }   
}
