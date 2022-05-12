using System.ComponentModel.DataAnnotations;

namespace L1.Models
{
    public class Challenge
    {
        [Key]
        public int Id { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string Text { get; set; }


        public ChallengeType Type { get; set; }

        public ChallengeDifficultyLevel DifficultyLevel { get; set; }

        public bool IsOpenForAll { get; set; }
    }

    public enum ChallengeType
    {
        CompleteTheSentence,
        TextAndQtoWord
    }

    public enum ChallengeDifficultyLevel
    {
        Easy, 
        Medium, 
        Hard
    }
}
