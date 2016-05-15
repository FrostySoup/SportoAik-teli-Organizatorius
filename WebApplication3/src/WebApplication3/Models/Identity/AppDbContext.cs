using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.AikstelesModeliai;
using WebApplication3.Models.TurnyroModeliai;

namespace WebApplication3.Models.Identity
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Renginys> Renginiai { get; set; }
        public DbSet<Aikstele> Aiksteles { get; set; }
        public DbSet<AikstelesKomentaras> AikstelesKomentarai { get; set; }
        public DbSet<AikstelesVertinimas> AikstelesVertinimai { get; set; }
        public DbSet<Turnyras> Turnyras { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TurnyroDalyvis>()
                .HasKey(t => new { t.KomandaID, t.TurnyrasID });

            builder.Entity<TurnyroDalyvis>()
                .HasOne(pt => pt.Turnyras)
                .WithMany(p => p.Dalyviai)
                .HasForeignKey(pt => pt.TurnyrasID);

            builder.Entity<TurnyroDalyvis>()
                .HasOne(pt => pt.Komanda)
                .WithMany(t => t.Turnyrai)
                .HasForeignKey(pt => pt.KomandaID);

            builder.Entity<UserRenginys>()
                .HasKey(t => new { t.RenginysId, t.ApplicationUserId });

            builder.Entity<UserRenginys>()
                .HasOne(pt => pt.Renginys)
                .WithMany(p => p.UserRenginys)
                .HasForeignKey(pt => pt.RenginysId);

            builder.Entity<UserRenginys>()
                .HasOne(pt => pt.ApplicationUser)
                .WithMany(t => t.UserRenginys)
                .HasForeignKey(pt => pt.ApplicationUserId);
        }

        public DbSet<Komanda> Komanda { get; set; }

    }
}