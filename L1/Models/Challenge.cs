using System.ComponentModel.DataAnnotations;

namespace L1.Models
{
    public class Challenge
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nummar")]
        public int OrderInSequence { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Display(Name = "Intro")]
        public string? Name { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Display(Name = "Tekstur")]
        public string? Text { get; set; }

        [Display(Name = "Frágreiding")]
        public string? Description { get; set; }
        [Display(Name = "Spurningur")]      
        public string? Question { get; set; }

        [Display(Name = "Slag")]
        public int TypeId { get; set; }

        [Display(Name = "Slag")]
        public ChallengeType Type { get; set; }

        public int DifficultyLevelId { get; set; }

        [Display(Name = "Torleikastig")]
        public ChallengeDifficultyLevel DifficultyLevel { get; set; }

        [Display(Name = "Legg út til öll")]
        public bool IsOpenForAll { get; set; }

        public int CorrectOptionId { get; set; }

        [Display(Name = "Svarmøguleikar")]
        public List<ChallengeOption> Options     { get; set; }
    }
}
