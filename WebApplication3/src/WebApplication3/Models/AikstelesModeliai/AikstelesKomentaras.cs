using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Identity;

namespace WebApplication3.Models.AikstelesModeliai
{
    public class AikstelesKomentaras
    {
        [Key]
        public string AikstelesKomentarasID { get; set; }
        public DateTime Data { get; set; }
        public string Komentaras { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Aikstele Aikstele { get; set; }
    }
}
