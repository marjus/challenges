using L1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace L1.ViewModels;

public class EditChallenge
{
    

    public Challenge Challenge { get; set; }    

    public List<SelectListItem> DifficultyLevels { get; set; }

    public List<SelectListItem> Types { get; set; }

    public EditChallenge()
    {
        DifficultyLevels = new List<SelectListItem>();
        DifficultyLevels.Add(new SelectListItem { Text = "Easy", Value = "E" });
        DifficultyLevels.Add(new SelectListItem { Text = "Medium", Value = "M" });
        DifficultyLevels.Add(new SelectListItem { Text = "Hard", Value = "H" });

        Types = new List<SelectListItem>();
        Types.Add(new SelectListItem { Text = "T1", Value = "T1" });
        Types.Add(new SelectListItem { Text = "T2", Value = "T2" });
        Types.Add(new SelectListItem { Text = "T3", Value = "T3" });
    }
}
