using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models
{
    [Table(name: "report_card", Schema ="public")]
    public class ReportCard
    {
        [Column("report_card_id")]
        [Key]
        public int ReportCardId { get; set; }

        [Column("employee_id")]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }

        [Column("working_time")]
        public double WorkingTime { get; set; }
    }
}
