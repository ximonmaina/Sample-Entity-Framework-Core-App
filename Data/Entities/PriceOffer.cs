using System.ComponentModel.DataAnnotations;

namespace MyFirstEfCoreApp.Data.Entities
{
    public class PriceOffer
    {
        private const int PromotionalTextLength = 200;
        public int PriceOfferId { get; set; }
        public decimal NewPrice { get; set; }
        [Required]
        [MaxLength(PromotionalTextLength)]
        public string PromotionalText { get; set; }

        // relationships
        public int BookId { get; set; }
    }
}
