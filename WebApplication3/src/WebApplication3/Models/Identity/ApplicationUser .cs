using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Book> Books { get; set; }
    }
}
