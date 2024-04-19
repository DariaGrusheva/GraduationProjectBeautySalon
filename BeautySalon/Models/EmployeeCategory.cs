using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models
{
    [Table(name: "employee_category", Schema = "public")]
    public class EmployeeCategory
    {
        [Column("employee_category_id")]
        [Key]
        public int EmployeeCategoryId { get; set; }

        [Column("employee_id")]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }


        [Column("category_id")]
        [ForeignKey(nameof(CategoryService))]
        public int CategoryId { get; set; }
        public CategoryService CategoryService { get; set; }
    }
}
