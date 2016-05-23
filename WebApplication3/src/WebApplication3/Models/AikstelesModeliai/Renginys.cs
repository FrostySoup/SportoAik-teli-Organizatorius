using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Identity;

namespace WebApplication3.Models.AikstelesModeliai
{
    public class Renginys
    {
        [Key]
        public string RenginysID { get; set; }

        [Required]
        [Display(Name = "Renginio data")]
        public DateTime Data { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Sporto šaka")]
        public string SportoSaka { get; set; }

        [Display(Name = "Renginio statusas")]
        public string Statusas { get; set; }

        [Required]
        [Range(1, 40, ErrorMessage = "Minimalus žaidėjų kiekis 1, maksimalus 40")]
        [Display(Name = "Žaidėjų skaičius")]
        public int ZaidejuKiekis { get; set; }

        public string RenginioAutoriausID { get; set; }

        public Aikstele Aikstele { get; set; }

        public ICollection<UserRenginys> UserRenginys { get; set; }
    }
}
