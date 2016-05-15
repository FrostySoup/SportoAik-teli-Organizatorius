using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.AikstelesModeliai
{
    public class Aikstele
    {
        [Key]
        public string AiksteleID { get; set; }
        public string LatY { get; set; }
        public double LongX { get; set; }
        public bool ArPatvirtinta { get; set; }
        public string Adresas { get; set; }
        public string Miestas { get; set; }

        public ICollection<AikstelesVertinimas> Vertinimai { get; set; }
        public ICollection<AikstelesKomentaras> Komentarai { get; set; }
       
    }
}
