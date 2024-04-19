using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace BeautySalon.Models
{
    [Table(name:"about_us", Schema = "public")]
    public class AboutUs
    {
        [Column("name_salon")]
        [Key]
        [Required]
        [StringLength(200, ErrorMessage = "Длина поля не должна превышать 200 символов")]
        public string NameSalon { get; set; }

        [Column("contact_number")]
        [Required]
        [StringLength(20, ErrorMessage = "Длина поля не должна превышать 20 символов")]
        public string ContactNumber { get; set; }

        [Column("address")]
        [Required]
        [StringLength(200, ErrorMessage = "Длина поля не должна превышать 200 символов")]
        public string? Address { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("worksheet")]
        [StringLength(100, ErrorMessage = "Длина поля не должна превышать 100 символов")]
        public string? Worksheet { get; set; }

        [Column("insta_link")]
        [StringLength(256, ErrorMessage = "Длина поля не должна превышать 256 символов")]
        public string? InstaLink { get; set; }

        [Column("vk_link")]
        [StringLength(256, ErrorMessage = "Длина поля не должна превышать 256 символов")]
        public string? VkLink { get; set; }

        [Column("ok_link")]
        [StringLength(256, ErrorMessage = "Длина поля не должна превышать 256 символов")]
        public string? OkLink { get; set; }

        [Column("any_link")]
        [StringLength(256, ErrorMessage = "Длина поля не должна превышать 256 символов")]
        public string? AnyLink { get; set; }
    }
}
