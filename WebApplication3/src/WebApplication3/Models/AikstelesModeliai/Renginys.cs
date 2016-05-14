using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.AikstelesModeliai
{
    public class Renginys
    {
        [Key]
        public string RenginysID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Renginio laikas")]
        public DateTime Data { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Sporto šaka")]
        public string SportoSaka { get; set; }

        [Display(Name = "Renginio statusas")]
        public bool ArPrasidejo { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Minimalus žaidėjų kiekis 1, maksimalus 20")]
        [Display(Name = "Žaidėjų skaičius vienoje komandoje")]
        public int ZaidejuKiekis { get; set; }

        public string RenginioAutoriausID { get; set; }

        public Aikstele Aikstele { get; set; }
    }
}
