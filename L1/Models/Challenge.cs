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

        public ChallengeType ChallengeType { get; set; }

        public bool OpenForAll { get; set; }
    }

    public enum ChallengeType
    {
        Talk, 
        TalkUnderstand, 
        Understand, 
        UnderstandRead,
        UnderstandWrite
    }
}
