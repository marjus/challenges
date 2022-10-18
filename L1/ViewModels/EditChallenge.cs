using L1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;

namespace L1.ViewModels;

public class EditChallenge
{
    public int Id { get; set; }

    public Challenge Challenge { get; set; }    

    public List<SelectListItem> DifficultyLevels { get; set; }

    public List<SelectListItem> Types { get; set; }

    public EditChallenge()
    {
        DifficultyLevels = new List<SelectListItem>();
        Types = new List<SelectListItem>();

        var difficultyLevelItems = Enum.GetValues(typeof(ChallengeDifficultyLevel)).Cast<ChallengeDifficultyLevel>().Select(d => new SelectListItem { Text = d.ToString(), Value = ((int)d).ToString() }).ToList();
        DifficultyLevels.AddRange(difficultyLevelItems);

        var typesOfChallenge = Enum.GetValues(typeof(ChallengeType)).Cast<ChallengeType>().Select(d => new SelectListItem { Text = d.ToString(), Value = ((int)d).ToString() }).ToList();
        Types.AddRange(typesOfChallenge);

        Challenge= new Challenge();
        Challenge.Options = new List<ChallengeOption>();
    }
}
