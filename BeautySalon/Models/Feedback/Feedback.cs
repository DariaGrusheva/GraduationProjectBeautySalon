using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models.Feedback
{
    [Table(name:"feedback", Schema ="public")]
    public class Feedback
    {
        [Key]
        [Column("feedback_id")]
        public int FeedbackId { get; set; }

        [Column("name_critic")]
        [StringLength(50, ErrorMessage = "Длина поля не должна превышать 50 символов")]
        public string NameCritic { get; set; } = "Не представился";

        [Column("feedback")]
        [Required]
        [StringLength(2000, ErrorMessage = "Длина поля не должна превышать 2000 символов")]
        public string FeedbackThis { get; set; }
        [Column("date_feedback")]
        public DateTime DateFeedback { get; set; } = DateTime.Now;
    }
}
