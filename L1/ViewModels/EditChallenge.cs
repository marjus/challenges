using L1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        DifficultyLevels.Add(new SelectListItem { Text = "Lætt", Value = "1" });
        DifficultyLevels.Add(new SelectListItem { Text = "Miðal", Value = "2" });
        DifficultyLevels.Add(new SelectListItem { Text = "Torført", Value = "3" });

        Types = new List<SelectListItem>();
        Types.Add(new SelectListItem { Text = "Tala", Value = "1" });
        Types.Add(new SelectListItem { Text = "Lestur", Value = "2" });
        Types.Add(new SelectListItem { Text = "Skilja", Value = "3" });
    }
}
