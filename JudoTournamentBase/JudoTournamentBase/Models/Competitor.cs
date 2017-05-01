using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JudoTournamentBase.Models
{
    public class Competitor : BaseEntity
    {
        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(Localization))]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName", ResourceType = typeof(Localization))]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Gender", ResourceType = typeof(Localization))]
        public int Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "DateOfBirth", ResourceType = typeof(Localization))]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Category", ResourceType = typeof(Localization))]
        public int Category { get; set; }

        [Display(Name = "Club", ResourceType = typeof(Localization))]
        public string Club { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Localization))]
        public string Country { get; set; }
    }
}