using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class ChallengeOption
    {
        public int Id { get; set; }

        public string? Content { get; set; }

        public bool IsCorrect { get; set; }
    }
}
