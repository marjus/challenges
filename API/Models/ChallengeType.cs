using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace API.Models
{
    public enum ChallengeType
    {
        [Display(Name = "Enda setning")]
        CompleteSentence = 1,

        [Display(Name = "Vel rætt orð")]
        TextAndQtoWord = 2,

        [Display(Name = "Matcha orð")]
        MatchWords = 3,

        [Display(Name = "Vel røttu mynd")]
        TextAndQtoImage = 4 
    }
}
