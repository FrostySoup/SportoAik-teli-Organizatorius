using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication3.Models.Identity;

namespace WebApplication3.Models.TurnyroModeliai
{
    public enum TurnyroBusena { Naujas = 0, Vykstantis = 1, Pasibaiges = 2};

    public class Turnyras
    {
        [Key]
        public int TurnyrasID { get; set; }
        [Required]
        public string Pavadinimas { get; set; }

        [Display(Name = "Komandų kiekis")]
        [Required]
        public int KomanduKiekis { get; set; }

        public TurnyroBusena TurnyroBusena { get; set; } = TurnyroBusena.Naujas;

        public ApplicationUser TurnyroAutorius { get; set; }
        public ICollection<TurnyroDalyvis> Dalyviai { get; set; }
    }


}