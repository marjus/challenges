using L1.Models;

namespace L1.ApiModels
{
    public class UserChallengesAM
    {
        public int UserId { get; set; }
        public string? UserKey { get; set; }

        public Challenge ActiveChallenge { get; set; }

        public List<Challenge> Challenges { get; set; }
    }
}
