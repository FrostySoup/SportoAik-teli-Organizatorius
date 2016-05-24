using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.AikstelesModeliai;

namespace WebApplication3.Models.TurnyroModeliai
{
    public enum PakvietimoBusena
    {
        Pateiktas = 0,
        Patvirtintas = 1,
        Pasibaiges = 2
    };

    public class TurnyroVarzybos
    {
        public TurnyroVarzybos()
        {
            SukurimoData = DateTime.Now;
        }

        [Key]
        public int TurnyroVarzybosID { get; set; }
        public DateTime SukurimoData { get; set; }
        public DateTime PrasidejimoData { get; set; }
        public PakvietimoBusena PakvietimoBusena { get; set; } = PakvietimoBusena.Pateiktas;

        public int TurnyrasID { get; set; }
        public string AiksteleID { get; set; }
        public int KomandaA_ID { get; set; }
        public int KomandaB_ID { get; set; }
    }
}
