using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JudoTournamentBase
{
    public class Helper
    {
        public static int Years(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                (((end.Month > start.Month) ||
                ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }
    }
}