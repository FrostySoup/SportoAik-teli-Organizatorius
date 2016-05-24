using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Identity;
using WebApplication3.Models.VartotojoModeliai;

namespace WebApplication3.Models.VartotojoModeliai
{
    public class UserProfileViewModel
    {
        public ApplicationUser users { get; set; }
        public Komentaras comment { get; set; }
        public Vertinimas rating { get; set; }
    }
}
