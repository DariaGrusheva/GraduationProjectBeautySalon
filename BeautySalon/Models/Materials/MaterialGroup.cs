using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models.Materials
{
    [Table(name: "material_group", Schema = "public")]
    public class MaterialGroup
    {
        [Column("group_id")]
        [Key]
        public int GroupId { get; set; }

        [Column("name_group")]
        [Required]
        [StringLength(100, ErrorMessage = "Длина поля не должна превышать 100 символов")]
        public string NameGroup { get; set; }

        public ICollection<Material> Materials { get; set; } = new List<Material>();

    }
}
