using System.Collections.Generic;
using WebApplication3.Models.AikstelesModeliai;
using WebApplication3.Models.TurnyroModeliai;

namespace WebApplication3.ViewModel.TurnyroVarzybosViewModel
{
    public class DetailsViewModel
    {
        public Turnyras Turnyras { get; set; }
        public TurnyroVarzybos turnyroVarzybos { get; set; }
        public List<Komanda> VisosTurnyroKomandos { get; set; }
        public TurnyroVarzybuKomentaras TurnyroVarzybuKomentaras { get; set; }
        public List<TurnyroVarzybuKomentaras> VisiKomentarai { get; set; }
        public List<Aikstele> VisosAiksteles { get; set; }
    }
}
