using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Identity;

namespace WebApplication3.Models
{
    public class Book
    {
        public int BookID { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public string Genre { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
    }
}
