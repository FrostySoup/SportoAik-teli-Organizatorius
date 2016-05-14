using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.AikstelesModeliai
{
    public class Aikstele
    {
        public string ID { get; set; }
        public string LatY { get; set; }
        public double LongX { get; set; }
        public bool ArPatvirtinta { get; set; }
        public string Adresas { get; set; }
        public string Miestas { get; set; }

        public ICollection<AikstelesVertinimas> vertinimai { get; set; }
        public ICollection<AikstelesKomentaras> komentarai { get; set; }
    }
}
