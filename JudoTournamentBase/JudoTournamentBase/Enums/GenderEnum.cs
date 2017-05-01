using Resources;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JudoTournamentBase.Enums
{
    public enum GenderEnum
    {
        [Display(Name = "Female", ResourceType = typeof(Localization))]
        FEMALE,
        [Display(Name = "Male", ResourceType = typeof(Localization))]
        MALE
    }
}