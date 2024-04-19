using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models
{
    [Table(name: "category_service", Schema = "public")]
    public class CategoryService
    {
        [Column("category_id")]
        [Key]
        public int CategoryId { get; set; }

        [Column("name_category")]
        [Required]
        [StringLength(100, ErrorMessage = "Длина поля не должна превышать 100 символов")]
        public string NameCategory { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<EmployeeCategory> EmployeeCategories { get; set; } = new List<EmployeeCategory>();
        public ICollection<Service> Services { get; set; } = new List<Service>();


    }
}
