using System.Collections.Generic;
using WebApplication3.Models.TurnyroModeliai;

namespace WebApplication3.ViewModel.RezultatoPasiulymoViewModeliai
{
    public class IndexViewModel
    {
        public Komanda Komanda_A { get; set; }
        public Komanda Komanda_B { get; set; }
        public RezultatoPasiulymas Komanda_A_Pasiulymas { get; set; }
        public RezultatoPasiulymas Komanda_B_Pasiulymas { get; set; }
        public TurnyroVarzybos TurnyroVarzybos { get; set; }

        public long Komanda_A_ChallongeID { get; set; }
        public Turnyras Turnyras { get; set; }
    }
}
