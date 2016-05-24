using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.AikstelesModeliai;

namespace WebApplication3.DataHelpers
{
    public class AiksteleMap
    {
        public string AiksteleID { get; set; }
        public string LatY { get; set; }
        public string LongX { get; set; }
        public string Adresas { get; set; }
        public string Miestas { get; set; }

        public AiksteleMap(Aikstele aikstele)
        {
            AiksteleID = aikstele.AiksteleID;
            LatY = aikstele.LatY;
            LongX = aikstele.LongX;
            Adresas = aikstele.Adresas;
            Miestas = aikstele.Miestas;
        }
    }
}
