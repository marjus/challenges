using System.ComponentModel.DataAnnotations.Schema;

namespace L1.Models
{
    public class ChallengeOption
    {
        public int Id { get; set; }
        public string? Content { get; set; }

        [NotMapped]
        public bool IsCorrect { get; set; }
    }
}
