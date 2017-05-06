using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JudoTournamentBase.Models
{
    public class Competitor : BaseEntity
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Localization))]
        [Display(Name = "FirstName", ResourceType = typeof(Localization))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Localization))]
        [Display(Name = "LastName", ResourceType = typeof(Localization))]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Localization))]
        [Display(Name = "Gender", ResourceType = typeof(Localization))]
        public int Gender { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Localization))]
        [DataType(DataType.Date)]
        [Display(Name = "DateOfBirth", ResourceType = typeof(Localization))]
        public DateTime DateOfBirth { get; set; }

        [NotMapped]
        [Display(Name = "Years", ResourceType = typeof(Localization))]
        public int Years
        {
            get
            {
                return Helper.Years(DateOfBirth, DateTime.Now);
            }
            set { }
        }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Localization))]
        [Range(5, 200, ErrorMessageResourceName = "ValueOutOfRange", ErrorMessageResourceType = typeof(Localization))]
        [Display(Name = "Weight", ResourceType = typeof(Localization))]
        public int Weight { get; set; }

        [Display(Name = "Category", ResourceType = typeof(Localization))]
        public Guid CategoryId
        {
            get
            {
                using (var context = new ApplicationDbContext())
                {
                    var category = context.Categories.Where(c => (int)c.Gender == Gender
                                                                    && c.Weight > Weight
                                                                    && (int)c.Age > Years)
                                                                    .OrderBy(c => c.Age)
                                                                    .FirstOrDefault();
                    return category.Id;
                }
            }
            set { }
        }
        public virtual Category Category { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Localization))]
        [Display(Name = "Club", ResourceType = typeof(Localization))]
        public Guid ClubId { get; set; }
        public virtual Club Club { get; set; }

        [NotMapped]
        [Display(Name = "Country", ResourceType = typeof(Localization))]
        public string Country { get; set; }
    }
}