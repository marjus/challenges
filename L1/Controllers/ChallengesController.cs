using L1.Models;
using L1.ApiModels;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json;
using L1.Data;
using Microsoft.EntityFrameworkCore;
using L1.ViewModels;

namespace L1.Controllers
{
    public class ChallengesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChallengesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Challenges != null ?
                        View(await _context.Challenges.ToListAsync()) :
                        Problem("Entity set 'Challenges'  is null.");
        }
        /*
                public string Index(string key)
                {
                  //  return (_context.Challenges.Any() ? View(_context.Challenges.ToList() : Problem(""));

                    var challenges = new UserChallengesAM();
                    challenges.Challenges = new List<Challenge>();

                    challenges.UserId = 1;
                    challenges.UserKey = "123";

                    challenges.ActiveChallenge = new Challenge
                    {
                        Id = 211,
                        Name = "Complete the sentence",
                        Text = "The grass is __",
                        Question = "What color is the grass?",
                        CorrectOptionId = 1,
                        Options = new List<ChallengeOption>() { 
                            new ChallengeOption { Id = 1, Content = "Green" }, 
                            new ChallengeOption { Id = 2, Content = "Red" },
                            new ChallengeOption { Id = 3, Content = "Blue" },
                            new ChallengeOption { Id = 4, Content = "Black" },
                        }
                    };

                    challenges.Challenges.Add(new Challenge
                    {
                        Id = 1,
                        Name = "Complete the sentence",
                        Text = "Water is __",
                        Question = "Water is what??",
                        CorrectOptionId = 3,
                        Options = new List<ChallengeOption>() {
                            new ChallengeOption { Id = 1, Content = "Alive" },
                            new ChallengeOption { Id = 2, Content = "Annoying" },
                            new ChallengeOption { Id = 3, Content = "Wet" },
                            new ChallengeOption { Id = 4, Content = "Green" },
                        }
                    });

                    challenges.Challenges.Add(new Challenge
                    {
                        Id = 2,
                        Name = "Match the word",
                        Text = "Hammer",

                        CorrectOptionId = 2,
                        Options = new List<ChallengeOption>() {
                            new ChallengeOption { Id = 1, Content = "B" },
                            new ChallengeOption { Id = 2, Content = "H" },
                            new ChallengeOption { Id = 3, Content = "G" },
                            new ChallengeOption { Id = 4, Content = "L" },
                        }
                    });

                    return JsonSerializer.Serialize(challenges, new JsonSerializerOptions {  DefaultIgnoreCondition= System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull});
                }
        */

        public string GetTestData()
        {
            var challenges = new UserChallengesAM();
            challenges.Challenges = new List<Challenge>();

            challenges.UserId = 1;
            challenges.UserKey = "123";

            challenges.ActiveChallenge = new Challenge
            {
                Id = 211,
                Name = "Complete the sentence",
                Text = "The grass is __",
                Question = "What color is the grass?",
                CorrectOptionId = 1,
                Options = new List<ChallengeOption>() {
                            new ChallengeOption { Id = 1, Content = "Green" },
                            new ChallengeOption { Id = 2, Content = "Red" },
                            new ChallengeOption { Id = 3, Content = "Blue" },
                            new ChallengeOption { Id = 4, Content = "Black" },
                        }
            };

            challenges.Challenges.Add(new Challenge
            {
                Id = 1,
                Name = "Complete the sentence",
                Text = "Water is __",
                Question = "Water is what??",
                CorrectOptionId = 3,
                Options = new List<ChallengeOption>() {
                            new ChallengeOption { Id = 1, Content = "Alive" },
                            new ChallengeOption { Id = 2, Content = "Annoying" },
                            new ChallengeOption { Id = 3, Content = "Wet" },
                            new ChallengeOption { Id = 4, Content = "Green" },
                        }
            });

            challenges.Challenges.Add(new Challenge
            {
                Id = 2,
                Name = "Match the word",
                Text = "Hammer",

                CorrectOptionId = 2,
                Options = new List<ChallengeOption>() {
                            new ChallengeOption { Id = 1, Content = "B" },
                            new ChallengeOption { Id = 2, Content = "H" },
                            new ChallengeOption { Id = 3, Content = "G" },
                            new ChallengeOption { Id = 4, Content = "L" },
                        }
            });

            return JsonSerializer.Serialize(challenges, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull });

        }

        public string GetAllChallenges()
        {
            var userChallenges = _context.Challenges
                .OrderBy(c => c.OrderInSequence)
                .ToList();

            var challenges = new UserChallengesAM();

            if (userChallenges.Any())
            {
                challenges.Challenges = userChallenges;
            }

            return JsonSerializer.Serialize(challenges, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull });
        }

        public string GetChallengesForUserProfile(UserProfile profile)
        {
            var userChallenges = _context.Challenges
                .Where(c => c.DifficultyLevel == profile.DifficultyLevel)
                .OrderBy(c=> c.OrderInSequence)
                .ToList();

            var challenges = new UserChallengesAM();

            if (userChallenges.Any())
            {
                
                challenges.Challenges = userChallenges;

                // Fetch the next userChallenge in the list and set it as active
#pragma warning disable CS8601 // Possible null reference assignment.
                challenges.ActiveChallenge = userChallenges.SkipWhile(c => c.OrderInSequence <= profile.CurrentSequencePosition)
                    .Skip(1)
                    .DefaultIfEmpty(userChallenges[0])
                    .FirstOrDefault();
#pragma warning restore CS8601 // Possible null reference assignment.

            }

            return JsonSerializer.Serialize(challenges, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull });
        }

        // GET: Challenges1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Challenges == null)
            {
                return NotFound();
            }

            var challenge = await _context.Challenges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (challenge == null)
            {
                return NotFound();
            }

            return View(challenge);
        }

        // GET: Challenges1/Create
        public IActionResult Create()
        {
            var vm = new EditChallenge();

            for(var i = 0; i < 4; i++)
            {
                vm.Challenge.Options.Add(new ChallengeOption { Id = i });
            }

            return View(vm);
        }

        // POST: Challenges1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Challenge challenge)
        {
            if (ModelState.IsValid)
            {
                var options = challenge.Options.Select(o => new ChallengeOption { Content = o.Content, IsCorrect = o.IsCorrect }).ToList();
                
                challenge.Options.Clear();
                challenge.Options.AddRange(options);

                _context.Add(challenge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(challenge);
        }

        // GET: Challenges1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Challenges == null)
            {
                return NotFound();
            }

            var challenge = await _context.Challenges.Include(c => c.Options).SingleOrDefaultAsync(c => c.Id == id);

            if (challenge == null || challenge.Options == null)
            {
                return NotFound();
            }

            var vm = new EditChallenge();

            vm.Id = id.Value;
            vm.Challenge = challenge;

            return View(vm);
        }

        // POST: Challenges1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Challenge challenge)
        {
            if (id != challenge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(challenge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChallengeExists(challenge.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(challenge);
        }

        // GET: Challenges1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Challenges == null)
            {
                return NotFound();
            }

            var challenge = await _context.Challenges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (challenge == null)
            {
                return NotFound();
            }

            return View(challenge);
        }

        // POST: Challenges1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Challenges == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Challenges'  is null.");
            }
            var challenge = await _context.Challenges.FindAsync(id);
            if (challenge != null)
            {
                _context.Challenges.Remove(challenge);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChallengeExists(int id)
        {
            return (_context.Challenges?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
