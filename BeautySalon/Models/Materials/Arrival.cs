using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models.Materials
{
    [Table(name: "arrival", Schema = "public")]
    public class Arrival
    {
        [Column("arrival_id")]
        [Key]
        public int ArrivalId { get; set; }

        [Column("date_arrival")]
        public DateTime DateArrival { get; set; }

        [Column("provider_id")]
        [ForeignKey(nameof(Provider))]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public ICollection<ArrivalComposition> ArrivalCompositions { get; set; } = new List<ArrivalComposition>();
    }
}
