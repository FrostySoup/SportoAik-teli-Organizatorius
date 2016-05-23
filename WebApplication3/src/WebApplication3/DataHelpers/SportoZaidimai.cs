﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.DataHelpers
{
    static public class RenginioStatusas
    {
        public enum Statusai
        {
            Neprasidėjes, Prasidėjes, Pasibaiges, Nutrauktas
        }
        static public string Zaidimas(int value)
        {
            switch (value)
            {
                case 0:
                    return "Neprasidėjes";
                case 1:
                    return "Prasidėjes";
                case 2:
                    return "Pasibaiges";
                case 3:
                    return "Nutrauktas";
                default:
                    return "Nepasirinkta";
            }
        }
    }
}
