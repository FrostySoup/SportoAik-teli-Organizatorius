using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.AikstelesModeliai
{
    public class Renginys
    {
        public string ID { get; set; }
        public DateTime data { get; set; }
        public string SportoŠaka { get; set; }
        public bool ArPrasidėjo { get; set; }
        public int ZaidejuKiekis { get; set; }
        public string renginioAutoriausID { get; set; }

        public Aikstele Aikstele { get; set; }
    }
}
