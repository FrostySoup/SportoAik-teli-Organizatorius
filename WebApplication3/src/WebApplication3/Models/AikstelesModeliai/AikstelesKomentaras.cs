using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Identity;

namespace WebApplication3.Models.AikstelesModeliai
{
    public class AikstelesKomentaras
    {
        public string ID { get; set; }
        public DateTime Data { get; set; }
        public string Komentaras { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Aikstele aikstele { get; set; }
    }
}
