using L1.Models;
using L1.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace L1.Controllers
{
    public class ChallengesController : Controller
    {
        public string Index(string key)
        {
            var challenges = new UserChallengesAM();
            challenges.Challenges = new List<Challenge>();

            challenges.Id = 1;
            challenges.Key = "123";

            challenges.ActiveChallenge = new Challenge
            {
                Id = 211,
                Name = "Enda setning",
                Text = "Grasid er __",
                Question = "Hvönn lit er grasid?",
                CorrectOptionId = 1,
                Options = new List<ChallengeOption>() { 
                    new ChallengeOption { Id = 1, Content = "Grönt" }, 
                    new ChallengeOption { Id = 2, Content = "Reytt" },
                    new ChallengeOption { Id = 3, Content = "Blátt" },
                    new ChallengeOption { Id = 4, Content = "Svart" },
                }
            };

            challenges.Challenges.Add(new Challenge
            {
                Id = 1,
                Name = "Enda setning",
                Text = "Vatnid er __",
                Question = "Hvat er vatn?",
                CorrectOptionId = 3,
                Options = new List<ChallengeOption>() {
                    new ChallengeOption { Id = 1, Content = "Livandi" },
                    new ChallengeOption { Id = 2, Content = "Irriterandi" },
                    new ChallengeOption { Id = 3, Content = "Vátt" },
                    new ChallengeOption { Id = 4, Content = "Grönt" },
                }
            });

            return JsonSerializer.Serialize(challenges);
        }
    }
}
