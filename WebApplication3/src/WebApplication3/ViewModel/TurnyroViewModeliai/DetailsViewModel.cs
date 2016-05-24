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
        public string PasiulymoAikstele { get; set; }
        public Turnyras Turnyras { get; set; }
        public TurnyroVarzybos TurnyroVarzybos { get; set; }
        public TurnyroDalyvis TurnyroDalyvis { get; set; }
        public List<Aikstele> Aiksteles { get; set; }
    }
}
