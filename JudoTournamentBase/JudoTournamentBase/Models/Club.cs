using JudoTournamentBase.Enums;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JudoTournamentBase.Models
{
    public class Club : BaseEntity
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Localization))]
        [Display(Name = "Name", ResourceType = typeof(Localization))]
        public string Gender { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Localization))]
        [Display(Name = "Country", ResourceType = typeof(Localization))]
        public string Country { get; set; }

        public Club()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }

}