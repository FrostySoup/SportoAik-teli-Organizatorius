using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace WebApplication3.Migrations
{
    public partial class reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Aikstele",
                columns: table => new
                {
                    AiksteleID = table.Column<string>(nullable: false),
                    Adresas = table.Column<string>(nullable: true),
                    ArPatvirtinta = table.Column<bool>(nullable: false),
                    LatY = table.Column<string>(nullable: true),
                    LongX = table.Column<double>(nullable: false),
                    Miestas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aikstele", x => x.AiksteleID);
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Renginys",
                columns: table => new
                {
                    RenginysID = table.Column<string>(nullable: false),
                    AiksteleAiksteleID = table.Column<string>(nullable: true),
                    ArPrasidejo = table.Column<bool>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    RenginioAutoriausID = table.Column<string>(nullable: true),
                    SportoSaka = table.Column<string>(nullable: false),
                    ZaidejuKiekis = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renginys", x => x.RenginysID);
                    table.ForeignKey(
                        name: "FK_Renginys_Aikstele_AiksteleAiksteleID",
                        column: x => x.AiksteleAiksteleID,
                        principalTable: "Aikstele",
                        principalColumn: "AiksteleID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => new { x.LoginProvider, x.ProviderKey });
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AikstelesKomentaras",
                columns: table => new
                {
                    AikstelesKomentarasID = table.Column<string>(nullable: false),
                    AiksteleAiksteleID = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Komentaras = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AikstelesKomentaras", x => x.AikstelesKomentarasID);
                    table.ForeignKey(
                        name: "FK_AikstelesKomentaras_Aikstele_AiksteleAiksteleID",
                        column: x => x.AiksteleAiksteleID,
                        principalTable: "Aikstele",
                        principalColumn: "AiksteleID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "AikstelesVertinimas",
                columns: table => new
                {
                    AikstelesVertinimasID = table.Column<string>(nullable: false),
                    AiksteleAiksteleID = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Vertinimas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AikstelesVertinimas", x => x.AikstelesVertinimasID);
                    table.ForeignKey(
                        name: "FK_AikstelesVertinimas_Aikstele_AiksteleAiksteleID",
                        column: x => x.AiksteleAiksteleID,
                        principalTable: "Aikstele",
                        principalColumn: "AiksteleID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "UserRenginys",
                columns: table => new
                {
                    RenginysId = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRenginys", x => new { x.RenginysId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_UserRenginys_Renginys_RenginysId",
                        column: x => x.RenginysId,
                        principalTable: "Renginys",
                        principalColumn: "RenginysID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    KomandaKomandaID = table.Column<int>(nullable: true),
                    KomandosId = table.Column<int>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Komanda",
                columns: table => new
                {
                    KomandaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KapitonasId = table.Column<string>(nullable: true),
                    Pavadinimas = table.Column<string>(nullable: true),
                    SearchForPlayers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komanda", x => x.KomandaID);
                    table.ForeignKey(
                        name: "FK_Komanda_ApplicationUser_KapitonasId",
                        column: x => x.KapitonasId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Turnyras",
                columns: table => new
                {
                    TurnyrasID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KomanduKiekis = table.Column<int>(nullable: false),
                    Pavadinimas = table.Column<string>(nullable: false),
                    PrasidejimoData = table.Column<DateTime>(nullable: false),
                    SukurimoData = table.Column<DateTime>(nullable: false),
                    TurnyroAutoriusId = table.Column<string>(nullable: true),
                    TurnyroBusena = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnyras", x => x.TurnyrasID);
                    table.ForeignKey(
                        name: "FK_Turnyras_ApplicationUser_TurnyroAutoriusId",
                        column: x => x.TurnyroAutoriusId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Komentaras",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    commentedUser = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentaras", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Komentaras_ApplicationUser_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Pakvietimas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    komandosId = table.Column<int>(nullable: false),
                    vartotojoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pakvietimas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pakvietimas_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "TurnyroDalyvis",
                columns: table => new
                {
                    KomandaID = table.Column<int>(nullable: false),
                    TurnyrasID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnyroDalyvis", x => new { x.KomandaID, x.TurnyrasID });
                    table.ForeignKey(
                        name: "FK_TurnyroDalyvis_Komanda_KomandaID",
                        column: x => x.KomandaID,
                        principalTable: "Komanda",
                        principalColumn: "KomandaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurnyroDalyvis_Turnyras_TurnyrasID",
                        column: x => x.TurnyrasID,
                        principalTable: "Turnyras",
                        principalColumn: "TurnyrasID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");
            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName");
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_AikstelesKomentaras_ApplicationUser_ApplicationUserId",
                table: "AikstelesKomentaras",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_AikstelesVertinimas_ApplicationUser_ApplicationUserId",
                table: "AikstelesVertinimas",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserRenginys_ApplicationUser_ApplicationUserId",
                table: "UserRenginys",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Book_ApplicationUser_ApplicationUserId",
                table: "Book",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Komanda_KomandaKomandaID",
                table: "AspNetUsers",
                column: "KomandaKomandaID",
                principalTable: "Komanda",
                principalColumn: "KomandaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Komanda_ApplicationUser_KapitonasId", table: "Komanda");
            migrationBuilder.DropTable("AspNetRoleClaims");
            migrationBuilder.DropTable("AspNetUserClaims");
            migrationBuilder.DropTable("AspNetUserLogins");
            migrationBuilder.DropTable("AspNetUserRoles");
            migrationBuilder.DropTable("AikstelesKomentaras");
            migrationBuilder.DropTable("AikstelesVertinimas");
            migrationBuilder.DropTable("UserRenginys");
            migrationBuilder.DropTable("Book");
            migrationBuilder.DropTable("TurnyroDalyvis");
            migrationBuilder.DropTable("Komentaras");
            migrationBuilder.DropTable("Pakvietimas");
            migrationBuilder.DropTable("AspNetRoles");
            migrationBuilder.DropTable("Renginys");
            migrationBuilder.DropTable("Turnyras");
            migrationBuilder.DropTable("Aikstele");
            migrationBuilder.DropTable("AspNetUsers");
            migrationBuilder.DropTable("Komanda");
        }
    }
}
