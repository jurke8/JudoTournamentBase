using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JudoTournamentBase.Models
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }

        [Display(Name = "DateCreated", ResourceType = typeof(Localization))]
        public DateTime DateCreated { get; set; }
    }
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
    }
}