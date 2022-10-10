﻿using System.ComponentModel.DataAnnotations;

namespace L1.Models
{
    public enum ChallengeDifficultyLevel
    {
        [Display(Name ="Lætt")]
        Easy = 11,

        [Display(Name = "Miðal")]
        Medium = 21,

        [Display(Name = "Torført")]
        Hard = 31
    }
}
