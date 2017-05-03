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
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeENum.U8,
                Weight = 18
            },
            new Category {
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeENum.U8,
                Weight = 20
            },
            new Category {
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeENum.U8,
                Weight = 22
            },
            new Category {
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeENum.U8,
                Weight = 25
            },
            new Category {
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeENum.U8,
                Weight = 28
            },
            new Category {
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeENum.U8,
                Weight = 32
            },
            new Category {
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeENum.U8,
                Weight = 36
            },
            new Category {
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeENum.U8,
                Weight = 40
            },
            new Category {
                Gender= Enums.GenderEnum.FEMALE,
                Age = Enums.AgeENum.U8,
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