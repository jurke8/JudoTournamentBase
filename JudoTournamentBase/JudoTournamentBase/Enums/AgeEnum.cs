using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JudoTournamentBase.Enums
{
    public enum AgeENum
    {
        [Display(Name = "U8", ResourceType = typeof(Localization))]
        U8 = 8,
        [Display(Name = "U10", ResourceType = typeof(Localization))]
        U10 = 10,
        [Display(Name = "U12", ResourceType = typeof(Localization))]
        U12 = 12,
        [Display(Name = "U14", ResourceType = typeof(Localization))]
        U14 = 14,
        [Display(Name = "U16", ResourceType = typeof(Localization))]
        U16 = 16,
        [Display(Name = "U18", ResourceType = typeof(Localization))]
        U18 = 18,
    }
}