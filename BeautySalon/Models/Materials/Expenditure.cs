using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models.Materials
{
    [Table(name: "expenditure", Schema = "public")]
    public class Expenditure
    {
        [Column("expenditure_id")]
        [Key]
        public int ExpenditureId { get; set; }

        [Column("material_id")]
        [ForeignKey(nameof(Material))]
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        [Column("employee_id")]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Column("service_id")]
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        [Column("volume_consumption")]
        public double VolumeConsumption { get; set; }

    }
}
