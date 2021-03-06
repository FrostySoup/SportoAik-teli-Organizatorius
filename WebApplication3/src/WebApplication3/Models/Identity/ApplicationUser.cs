﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.AikstelesModeliai;
using WebApplication3.Models.VartotojoModeliai;
using WebApplication3.Models.TurnyroModeliai;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Book> Books { get; set; }

        public string FullName { get; set; }

        public int KomandosId { get; set; }

        public double Vidurkis { get; set; }

        public int VertiniusiuKiekis { get; set; }

        public ICollection<AikstelesVertinimas> Vertinimai { get; set; }

        public ICollection<AikstelesKomentaras> Komentarai { get; set; }

        public ICollection<Pakvietimas> Pakvietimai { get; set; }

        public ICollection<Komentaras> UserComments { get; set; }

        public ICollection<Vertinimas> UserRatings { get; set; }

        public List<UserRenginys> UserRenginys { get; set; }
    }
}

