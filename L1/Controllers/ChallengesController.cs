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
    }
}
