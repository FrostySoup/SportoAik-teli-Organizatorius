using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.TurnyroModeliai
{
    public class RezultatoPasiulymas
    {
        [Key]
        public int RezultatoPasiulymasID { get; set; }
        public TurnyroVarzybos TurnyroVarzybos { get; set; }
        public Komanda Komanda { get; set; }
        public int KomandaA_Rez { get; set; }
        public int KomandaB_Rez { get; set; }
    }
}