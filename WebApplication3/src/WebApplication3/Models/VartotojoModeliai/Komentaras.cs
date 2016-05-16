using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebApplication3.Models.Identity;


namespace WebApplication3.Models.VartotojoModeliai
{
    public class Komentaras
    {
        [Key]
        public int CommentId { get; set; }

        public string Comment { get; set; }

        public string userId { get; set; }

        public ApplicationUser user { get; set; }

        public string commentedUser { get; set; }

        public DateTime Date { get; set; }
    }
}
