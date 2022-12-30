using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class ChallengeOption
    {
        public int Id { get; set; }

        [Display(Name ="Valmøguleiki")]
        public string? Content { get; set; }

        [Display(Name = "Rætt svar")]
        public bool IsCorrect { get; set; }

        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }
    }
}
