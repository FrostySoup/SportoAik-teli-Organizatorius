using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.VartotojoModeliai
{
    public class PakvietimasView
    {
        [Key]
        public int Id { get; set; }

        public string vartotojoId { get; set; }

        public int komandosId { get; set; }


    }
}
