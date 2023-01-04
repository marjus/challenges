using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Challenge
    {
        [Key]
        public int Id { get; set; }

        public int OrderInSequence { get; set; }

        public string Name { get; set; }

        public string? Text { get; set; }

        public string? Description { get; set; }
        public string? Question { get; set; }

        public int TypeId { get; set; }

        public ChallengeType Type { get; set; }

        public int DifficultyLevelId { get; set; }

        [Display(Name = "Torleikastig")]
        public ChallengeDifficultyLevel DifficultyLevel { get; set; }

        public bool IsOpenForAll { get; set; }

        public int CorrectOptionId { get; set; }

        public List<ChallengeOption> Options { get; set; }
    }
}
