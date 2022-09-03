using System.ComponentModel.DataAnnotations;

namespace L1.Models
{
    public class ChallengeResult
    {
        [Key]
        public int Id { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsPassed { get; set; }

    }
}
