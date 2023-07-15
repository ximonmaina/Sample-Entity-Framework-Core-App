using System.ComponentModel.DataAnnotations;

namespace MyFirstEfCoreApp.Data.Entities
{
    public class Review
    {
        private const int MaxLength = 100;
        public int ReviewId { get; set; }
        [MaxLength(MaxLength)]
        public string VoterName { get; set; }
        public int NumStars { get; set; }
        public string Comment { get; set; }

        // relationships
        public int BookId { get; set; }
    }
}
