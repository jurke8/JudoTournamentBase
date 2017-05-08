using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JudoTournamentBase.Enums
{
    public enum AgeEnum
    {
        [Display(Name = "U8")]
        U8 = 8,
        [Display(Name = "U10")]
        U10 = 10,
        [Display(Name = "U12")]
        U12 = 12,
        [Display(Name = "U14")]
        U14 = 14,
        [Display(Name = "U16")]
        U16 = 16,
        [Display(Name = "U18")]
        U18 = 18,
    }
}