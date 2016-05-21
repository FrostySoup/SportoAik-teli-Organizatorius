using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication3.Models.Identity;

namespace WebApplication3.Models.TurnyroModeliai
{
    public enum TurnyroBusena {
        Naujas = 0,
        Vykstantis = 1,
        [Display(Name = "Pasibaigęs")]
        Pasibaiges = 2
    };

    public enum TurnyroSportoSaka {
        [Display(Name = "Krepšinis")]
        Krepsinis = 0,
        Futbolas = 1
    };

    public class Turnyras
    {
        public Turnyras()
        {
            SukurimoData = DateTime.Now;
            Dalyviai = new List<TurnyroDalyvis>();
        }

        [Key]
        public int TurnyrasID { get; set; }

        [Required(ErrorMessage = "Įveskite turnyro pavadinimą")]
        [Display(Name = "Pavadinimas")]
        [StringLength(60, ErrorMessage = "Turnyro pavadinimo ilgis turėtų būti tarp 5 ir 60 simbolių", MinimumLength = 5)]
        public string Pavadinimas { get; set; }

        [Required]
        [Display(Name = "Komandų kiekis")]
        public int KomanduKiekis { get; set; }

        [Required]
        [Display(Name = "Turnyro formatas")]
        public int MinZaidejuKiekisKomandoje { get; set; }

        [Display(Name = "Turnyro būsena")]
        public TurnyroBusena TurnyroBusena { get; set; } = TurnyroBusena.Naujas;

        [Display(Name = "Sporto šaka")]
        public TurnyroSportoSaka TurnyroSportoSaka { get; set; } = TurnyroSportoSaka.Krepsinis;

        [Display(Name = "Turnyro autorius")]
        public ApplicationUser TurnyroAutorius { get; set; }

        public DateTime SukurimoData { get; set; }
        public DateTime PrasidejimoData { get; set; }
        public string ChallongeAddress { get; set; }
        public ICollection<TurnyroDalyvis> Dalyviai { get; set; }
    }


}