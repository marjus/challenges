using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L1.Models
{
    public class ChallengeOption
    {
        public int Id { get; set; }

        [Display(Name ="Valmøguleiki")]
        public string? Content { get; set; }

        [Display(Name = "Rætt svar")]
        public bool IsCorrect { get; set; }
    }
}
