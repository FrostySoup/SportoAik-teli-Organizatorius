using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.AikstelesModeliai;
using WebApplication3.Models.Identity;

namespace WebApplication3.Helpers
{
    public static class PatikrintiArNevertino
    {
        public static bool patikrinti(AppDbContext _context, ApplicationUser user, Aikstele aikstele)
        {
            foreach (AikstelesVertinimas vertinimasUser in user.Vertinimai)
            {
                foreach (AikstelesVertinimas vertinimasAiks in aikstele.Vertinimai)
                {
                    if (vertinimasUser.AikstelesVertinimasID.Equals(vertinimasAiks.AikstelesVertinimasID))
                        return true;
                }
            }
            return false;
        }
    }
}
