using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.TurnyroModeliai;

namespace WebApplication3.ViewModel.TurnyroViewModeliai
{
    public class IndexViewModel
    {
        public IEnumerable<Turnyras> Turnyrai { get; set; }
        public int? Type { get; set; }
    }
}
