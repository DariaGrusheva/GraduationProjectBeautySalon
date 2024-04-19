using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models.Materials
{
    [Table(name: "arrival_composition", Schema = "public")]
    public class ArrivalComposition
    {
        [Column("arrival_composition_id")]
        [Key]
        public int ArrivalCompositionId { get; set; }

        [Column("arrival_id")]
        [ForeignKey(nameof(Arrival))]
        public int ArrivalId { get; set; }
        public Arrival Arrival { get; set; }

        [Column("material_id")]
        [ForeignKey(nameof(Material))]
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
