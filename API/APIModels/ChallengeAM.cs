using API.Models;

namespace API.APIModels
{
    public class ChallengeAM
    {
        public int Id { get; set; }

        public int OrderInSequence { get; set; }

        public string? Name { get; set; }

        public string? Text { get; set; }

        public string? Description { get; set; }

        public string? Question { get; set; }

        public List<ChallengeOptionAM> Options { get; set; }
    }

    public class ChallengeOptionAM
    {

        public string? Content { get; set; }

        public bool IsCorrect { get; set; }
    }
}
