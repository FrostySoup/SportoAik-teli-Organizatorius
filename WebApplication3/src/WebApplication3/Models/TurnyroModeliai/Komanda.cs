using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication3.Models.Identity;

namespace WebApplication3.Models.TurnyroModeliai
{

    public class Komanda
    {

        [Key]
        public int KomandaID { get; set; }
        public string Pavadinimas { get; set; }

        public ApplicationUser Kapitonas { get; set; }
        public List<ApplicationUser> Nariai { get; set; }
        public ICollection<TurnyroDalyvis> Turnyrai { get; set; }

        public string SearchForPlayers { get; set; }
    }
}