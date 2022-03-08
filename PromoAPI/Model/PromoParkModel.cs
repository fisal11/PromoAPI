using System.ComponentModel.DataAnnotations;

namespace PromoAPI.Model
{
    public class PromoParkModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Add Title filed")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Add Sorce filed")]

        public string Sorce { get; set; }
        [Required(ErrorMessage = "Please Add Descbtion filed")]

        public string Descbtion { get; set; }
        [Required(ErrorMessage = "Please Add Date filed")]

        public DateTime Date { get; set; }

    }
}
