using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using WebApplication3.Models.Identity;

namespace WebApplication3.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20160515162942_Laikopakeitimai")]
    partial class Laikopakeitimai
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("WebApplication3.Models.AikstelesModeliai.Aikstele", b =>
                {
                    b.Property<string>("AiksteleID");

                    b.Property<string>("Adresas");

                    b.Property<bool>("ArPatvirtinta");

                    b.Property<string>("LatY");

                    b.Property<double>("LongX");

                    b.Property<string>("Miestas");

                    b.HasKey("AiksteleID");
                });

            modelBuilder.Entity("WebApplication3.Models.AikstelesModeliai.AikstelesKomentaras", b =>
                {
                    b.Property<string>("AikstelesKomentarasID");

                    b.Property<string>("AiksteleAiksteleID");

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Komentaras");

                    b.HasKey("AikstelesKomentarasID");
                });

            modelBuilder.Entity("WebApplication3.Models.AikstelesModeliai.AikstelesVertinimas", b =>
                {
                    b.Property<string>("AikstelesVertinimasID");

                    b.Property<string>("AiksteleAiksteleID");

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("Vertinimas");

                    b.HasKey("AikstelesVertinimasID");
                });

            modelBuilder.Entity("WebApplication3.Models.AikstelesModeliai.Renginys", b =>
                {
                    b.Property<string>("RenginysID");

                    b.Property<string>("AiksteleAiksteleID");

                    b.Property<bool>("ArPrasidejo");

                    b.Property<DateTime>("Data");

                    b.Property<string>("RenginioAutoriausID");

                    b.Property<string>("SportoSaka")
                        .IsRequired();

                    b.Property<int>("ZaidejuKiekis");

                    b.HasKey("RenginysID");
                });

            modelBuilder.Entity("WebApplication3.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Genre");

                    b.Property<decimal>("Price");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("BookID");
                });

            modelBuilder.Entity("WebApplication3.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("KomandaKomandaID");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("WebApplication3.Models.TurnyroModeliai.Komanda", b =>
                {
                    b.Property<int>("KomandaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("KapitonasId");

                    b.Property<string>("Pavadinimas");

                    b.HasKey("KomandaID");
                });

            modelBuilder.Entity("WebApplication3.Models.TurnyroModeliai.Turnyras", b =>
                {
                    b.Property<int>("TurnyrasID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KomanduKiekis");

                    b.Property<string>("Pavadinimas");

                    b.Property<string>("TurnyroAutoriusId");

                    b.Property<int>("TurnyroBusena");

                    b.HasKey("TurnyrasID");
                });

            modelBuilder.Entity("WebApplication3.Models.TurnyroModeliai.TurnyroDalyvis", b =>
                {
                    b.Property<int>("KomandaID");

                    b.Property<int>("TurnyrasID");

                    b.HasKey("KomandaID", "TurnyrasID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApplication3.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApplication3.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("WebApplication3.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WebApplication3.Models.AikstelesModeliai.AikstelesKomentaras", b =>
                {
                    b.HasOne("WebApplication3.Models.AikstelesModeliai.Aikstele")
                        .WithMany()
                        .HasForeignKey("AiksteleAiksteleID");

                    b.HasOne("WebApplication3.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("WebApplication3.Models.AikstelesModeliai.AikstelesVertinimas", b =>
                {
                    b.HasOne("WebApplication3.Models.AikstelesModeliai.Aikstele")
                        .WithMany()
                        .HasForeignKey("AiksteleAiksteleID");

                    b.HasOne("WebApplication3.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("WebApplication3.Models.AikstelesModeliai.Renginys", b =>
                {
                    b.HasOne("WebApplication3.Models.AikstelesModeliai.Aikstele")
                        .WithMany()
                        .HasForeignKey("AiksteleAiksteleID");
                });

            modelBuilder.Entity("WebApplication3.Models.Book", b =>
                {
                    b.HasOne("WebApplication3.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("WebApplication3.Models.Identity.ApplicationUser", b =>
                {
                    b.HasOne("WebApplication3.Models.TurnyroModeliai.Komanda")
                        .WithMany()
                        .HasForeignKey("KomandaKomandaID");
                });

            modelBuilder.Entity("WebApplication3.Models.TurnyroModeliai.Komanda", b =>
                {
                    b.HasOne("WebApplication3.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("KapitonasId");
                });

            modelBuilder.Entity("WebApplication3.Models.TurnyroModeliai.Turnyras", b =>
                {
                    b.HasOne("WebApplication3.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("TurnyroAutoriusId");
                });

            modelBuilder.Entity("WebApplication3.Models.TurnyroModeliai.TurnyroDalyvis", b =>
                {
                    b.HasOne("WebApplication3.Models.TurnyroModeliai.Komanda")
                        .WithMany()
                        .HasForeignKey("KomandaID");

                    b.HasOne("WebApplication3.Models.TurnyroModeliai.Turnyras")
                        .WithMany()
                        .HasForeignKey("TurnyrasID");
                });
        }
    }
}
