using JudoTournamentBase.Enums;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JudoTournamentBase.Models
{
    public class Category : BaseEntity
    {
        [Display(Name = "Name", ResourceType = typeof(Localization))]
        public string Name { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(Localization))]
        public GenderEnum Gender { get; set; }

        [Display(Name = "Age", ResourceType = typeof(Localization))]
        public AgeEnum Age { get; set; }

        [Display(Name = "Weight", ResourceType = typeof(Localization))]
        public int Weight { get; set; }

        public Category()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }

}