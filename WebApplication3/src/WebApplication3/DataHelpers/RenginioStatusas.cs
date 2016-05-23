using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.DataHelpers
{
    static public class Sportas
    {
        public enum SportoZaidimai
        {
            Krepšinis, Futbolas, Tenisas, Tinklinis
        }
        static public string Zaidimas(int value)
        {
            switch (value)
            {
                case 0:
                    return "Krepšinis";
                case 1:
                    return "Futbolas";
                case 2:
                    return "Tenisas";
                case 3:
                    return "Tinklinis";
                default:
                    return "Nepasirinkta";
            }
        }
    }
}
