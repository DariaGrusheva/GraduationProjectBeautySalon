using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BeautySalon.Models.Materials
{
    [Table(name: "provider", Schema = "public")]
    public class Provider
    {
        [Column("provider_id")]
        [Key]
        public int ProviderId { get; set; }

        [Column("name_organization")]
        [Required]
        [StringLength(100, ErrorMessage = "Длина поля не должна превышать 100 символов")]
        public string NameOrganization { get; set; }

        [Column("address")]
        [Required]
        [StringLength(100, ErrorMessage = "Длина поля не должна превышать 100 символов")]
        public string Address { get; set; }

        [Column("phone_number")]
        [Required]
        [StringLength(30, ErrorMessage = "Длина поля не должна превышать 30 символов")]
        public string PhoneNumber { get; set; }

        public ICollection<Arrival> Arrivals { get; set; } = new List<Arrival>();
    }
}
