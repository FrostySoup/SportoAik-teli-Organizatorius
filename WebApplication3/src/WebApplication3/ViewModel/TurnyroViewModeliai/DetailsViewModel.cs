using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.AikstelesModeliai;
using WebApplication3.Models.TurnyroModeliai;

namespace WebApplication3.ViewModel.TurnyroViewModeliai
{
    public class DetailsViewModel
    {
        public Aikstele Aikstele { get; set; }
        public Turnyras Turnyras { get; set; }
        public Komanda Komanda { get; set; }
        public TurnyroVarzybos TurnyroVarzybos { get; set; }
        public RezultatoPasiulymas RezultatoPasiulymas { get; set; }
        public TurnyroDalyvis TurnyroDalyvis { get; set; }
        public List<Aikstele> Aiksteles { get; set; }
        public List<TurnyroVarzybos> VisosTurnyroVarzybos { get; set; }
        public List<Komanda> VisosTurnyroKomandos { get; set; }
    }
}
