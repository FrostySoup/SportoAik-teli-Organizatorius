using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.AikstelesModeliai;

namespace WebApplication3.Helpers
{
    public class AikstelesCommentViewModel
    {
        public Aikstele Aikstele { get; set; }
        public AikstelesKomentaras Komentaras { get; set; }
        public AikstelesVertinimas Vertinimas { get; set; }
    }
}
