using System.ComponentModel.DataAnnotations;

namespace Endurvenjing.Models;

public class UserProfile
{
    [Key]
    public int Id { get; set; }

    public string Key { get; set; }

    public string Name { get; set; }

    public int CurrentSequencePosition { get; set; }

    public ChallengeDifficultyLevel DifficultyLevel { get; set; }

    public List<Challenge> OpenChallenges { get; set; }

    public List<ChallengeResult> CompletedChallenges{ get; set; }
}
