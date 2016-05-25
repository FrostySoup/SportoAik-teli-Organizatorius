using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebApplication3.Models.Identity;


namespace WebApplication3.Models.VartotojoModeliai
{
    public class Vertinimas
    {
        [Key]
        public int RatingId { get; set; }

        public int Rating { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string RatedUser { get; set; }

        public DateTime Date { get; set; }
    }
}
