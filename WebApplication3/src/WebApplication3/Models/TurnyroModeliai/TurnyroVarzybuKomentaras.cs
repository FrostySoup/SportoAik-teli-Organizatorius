using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.AikstelesModeliai;
using WebApplication3.Models.Identity;

namespace WebApplication3.Models.TurnyroModeliai
{
    public class TurnyroVarzybuKomentaras
    {
        public TurnyroVarzybuKomentaras()
        {
            Data = DateTime.Now;
        }

        [Key]
        public int TurnyroVarzybuKomentarasID { get; set; }
        public DateTime Data { get; set; }
        public string Komentaras { get; set; }
        public ApplicationUser KomentaroAutorius { get; set; }
        public TurnyroVarzybos TurnyroVarzybos { get; set; }
    }
}
