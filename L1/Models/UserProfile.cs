using System.ComponentModel.DataAnnotations;

namespace L1.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public List<Challenge> OpenChallenges { get; set; }

        public List<ChallengeResult> CompletedChallenges{ get; set; }
    }
}
