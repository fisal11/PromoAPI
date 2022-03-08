using System.ComponentModel.DataAnnotations;

namespace PromoAPI.Model.DTO
{
    public class PromoParkDTO
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Sorce { get; set; }
        public string Descbtion { get; set; }
        public DateTime Date { get; set; }

    }
}
