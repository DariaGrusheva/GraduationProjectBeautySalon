using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models
{
    [Table(name: "specialization", Schema = "public")]
    public class Specialization
    {
        [Column("specialization_id")]
        [Key]
        public int SpecializationId { get; set; }
        [Column("name")]
        [Required]
        [StringLength(50, ErrorMessage ="Длина поля не должна превышать 50 символов")]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }=new List<Employee>();

    }
}
