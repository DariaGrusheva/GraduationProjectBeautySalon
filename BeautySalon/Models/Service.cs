using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BeautySalon.Models.Materials;

namespace BeautySalon.Models
{
    [Table(name: "service", Schema = "public")]
    public class Service
    {
        [Column("service_id")]
        [Key]
        public int ServiceId { get; set; }

        [Column("category_id")]
        [ForeignKey(nameof(CategoriesServices))]
        public int CategoryId { get; set; }
        public CategoryService CategoriesServices { get; set; }

        [Column("name_service")]
        [Required]
        [StringLength(50, ErrorMessage = "Длина поля не должна превышать 50 символов")]
        public string NameService { get; set; }

        [Column("execution_time")]
        public TimeSpan ExecutionTime { get; set; }

        [Column("price")]
        public double Price { get; set; }

        public ICollection<Record> Records { get; set; } = new List<Record>();
        public ICollection<Expenditure> Expenditures { get; set; } = new List<Expenditure>();
    }
}
