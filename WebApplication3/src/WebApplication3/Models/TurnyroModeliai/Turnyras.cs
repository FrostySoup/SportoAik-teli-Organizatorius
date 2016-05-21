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
        public Turnyras()
        {
            SukurimoData = DateTime.Now;
            Dalyviai = new List<TurnyroDalyvis>();
        }

        [Key]
        public int TurnyrasID { get; set; }

        [Required]
        [Display(Name = "Pavadinimas")]
        public string Pavadinimas { get; set; }

        [Required]
        [Display(Name = "Komandų kiekis")]
        public int KomanduKiekis { get; set; }

        public DateTime SukurimoData { get; set; }
        public DateTime PrasidejimoData { get; set; }
        public TurnyroBusena TurnyroBusena { get; set; } = TurnyroBusena.Naujas;
        public ApplicationUser TurnyroAutorius { get; set; }
        public ICollection<TurnyroDalyvis> Dalyviai { get; set; }
    }


}