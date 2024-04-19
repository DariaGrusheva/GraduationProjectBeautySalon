using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models
{
    [Table(name: "record", Schema ="public")]
    public class Record
    {
        [Column("record_id")]
        [Key]
        public int RecordId { get; set; }

        [Column("date_recording")]
        public DateTime DateRecording { get; set; }

        [Column("time_recording")]
        public TimeSpan TimeRecording { get; set; }

        [Column("employee_id")]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId {  get; set; }
        public Employee Employee { get; set; }


        [Column("client_id")]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Column("service_id")]
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        [Column("confirmation")]
        public bool Confirmation { get; set; }

    }
}
