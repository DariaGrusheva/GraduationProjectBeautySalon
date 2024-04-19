using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models.Materials
{
    [Table(name: "materiaal", Schema = "public")]
    public class Material
    {
        [Column("materiaal_id")]
        [Key]
        public int MateriaalId { get; set; }

        [Column("group_id")]
        [ForeignKey(nameof(MaterialGroup))]
        public int GroupId { get; set; }
        public MaterialGroup MaterialGroup { get; set; }

        [Column("name_material")]
        [Required]
        [StringLength(200, ErrorMessage = "Длина поля не должна превышать 200 символов")]
        public string NameMateriaal { get; set; }

        [Column("price_material")]
        public double PriceMateriaal { get; set; }

        public ICollection<ArrivalComposition> ArrivalCompositions { get; set; } = new List<ArrivalComposition>();
        public ICollection<Expenditure> Expenditures { get; set; } = new List<Expenditure>();

    }
}
