using L1.Models;

namespace L1.ApiModels
{
    public class UserChallengesAM
    {
        public int Id { get; set; }
        public string Key { get; set; }

        public Challenge ActiveChallenge { get; set; }

        public List<Challenge> Challenges { get; set; }
    }
}
