using System.ComponentModel.DataAnnotations;
using WebApplication3.Models.Identity;

namespace WebApplication3.Models.AikstelesModeliai
{
    public class AikstelesVertinimas
    {
        [Key]
        public string AikstelesVertinimasID { get; set; }
        public int Vertinimas { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Aikstele Aikstele { get; set; }
    }
}