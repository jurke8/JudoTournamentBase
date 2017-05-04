using JudoTournamentBase.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JudoTournamentBase.DummyData
{
    public class RolesDummy
    {
        private static List<IdentityRole> _instance = new List<IdentityRole>()
        {
            new IdentityRole {
                Name = "Admin"
            },
            new IdentityRole {
                Name = "User"
            }
        };
        public static List<IdentityRole> Data
        {
            get
            {
                return _instance;
            }
        }
    }
}