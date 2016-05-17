using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Identity;

namespace WebApplication3.DataHelpers
{
    public class TupleBoolUser
    {
        public bool canUse { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public TupleBoolUser(bool canU, List<ApplicationUser> Usrs)
        {
            canUse = canU;
            Users = Usrs;
        }
    }
}
