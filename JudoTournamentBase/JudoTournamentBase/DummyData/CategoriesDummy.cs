using JudoTournamentBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JudoTournamentBase.DummyData
{
    public class CategoriesDummy
    {
        private static List<Category> _instance = new List<Category>()
        {
            new Category {
                Name = "curice U8 -18",
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeEnum.U8,
                Weight = 18
            },
            new Category {
                Name = "curice U8 -20",
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeEnum.U8,
                Weight = 20
            },
            new Category {
                Name = "curice U8 -22",
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeEnum.U8,
                Weight = 22
            },
            new Category {
                Name = "curice U8 -25",
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeEnum.U8,
                Weight = 25
            },
            new Category {
                Name = "curice U8 -28",
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeEnum.U8,
                Weight = 28
            },
            new Category {
                Name = "curice U8 -32",
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeEnum.U8,
                Weight = 32
            },
            new Category {
                Name = "curice U8 -36",
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeEnum.U8,
                Weight = 36
            },
            new Category {
                Name = "curice U8 -40",
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeEnum.U8,
                Weight = 40
            },
            new Category {
                Name = "curice U8 +40",
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeEnum.U8,
                Weight = 999
            }
        };
        public static List<Category> Data
        {
            get
            {
                return _instance;
            }
        }
    }
}