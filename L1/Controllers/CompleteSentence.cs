using L1.Data;
using L1.Models;
using Microsoft.AspNetCore.Mvc;

namespace L1.Controllers
{
    public class CompleteSentence : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompleteSentence(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
       //     var challenges = _context.Challenges.Where(c=> c.Type == Models.ChallengeType.CompleteTheSentence).ToList();
            var challenges = new List<Challenge>();
            challenges.Add(new Challenge { Id = 1, Name = "Enda setningin", DifficultyLevel = ChallengeDifficultyLevel.Medium, IsOpenForAll = true, Text = "Enda setningin", Type = ChallengeType.CompleteTheSentence };

            return View(challenges);
        }

        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Challenge challenge)
        {
            if(ModelState.IsValid)
            {

            }

            return View(challenge);
        }
    }
}
