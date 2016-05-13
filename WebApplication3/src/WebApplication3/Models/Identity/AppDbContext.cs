using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Identity
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<ApplicationUser>()
            //    .HasMany(b => b.Books)
            //    .WithOne();          
        }

    }
}