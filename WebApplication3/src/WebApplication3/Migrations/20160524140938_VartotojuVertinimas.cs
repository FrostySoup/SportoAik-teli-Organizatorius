using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace WebApplication3.Migrations
{
    public partial class VartotojuVertinimas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_UserRenginys_ApplicationUser_ApplicationUserId", table: "UserRenginys");
            migrationBuilder.DropForeignKey(name: "FK_UserRenginys_Renginys_RenginysId", table: "UserRenginys");
            migrationBuilder.DropForeignKey(name: "FK_TurnyroDalyvis_Komanda_KomandaID", table: "TurnyroDalyvis");
            migrationBuilder.DropForeignKey(name: "FK_TurnyroDalyvis_Turnyras_TurnyrasID", table: "TurnyroDalyvis");
            migrationBuilder.CreateTable(
                name: "Vertinimas",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    RatedUser = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vertinimas", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Vertinimas_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddColumn<int>(
                name: "VertiniusiuKiekis",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<double>(
                name: "Vidurkis",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
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
                name: "FK_UserRenginys_ApplicationUser_ApplicationUserId",
                table: "UserRenginys",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_UserRenginys_Renginys_RenginysId",
                table: "UserRenginys",
                column: "RenginysId",
                principalTable: "Renginys",
                principalColumn: "RenginysID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_TurnyroDalyvis_Komanda_KomandaID",
                table: "TurnyroDalyvis",
                column: "KomandaID",
                principalTable: "Komanda",
                principalColumn: "KomandaID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_TurnyroDalyvis_Turnyras_TurnyrasID",
                table: "TurnyroDalyvis",
                column: "TurnyrasID",
                principalTable: "Turnyras",
                principalColumn: "TurnyrasID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_UserRenginys_ApplicationUser_ApplicationUserId", table: "UserRenginys");
            migrationBuilder.DropForeignKey(name: "FK_UserRenginys_Renginys_RenginysId", table: "UserRenginys");
            migrationBuilder.DropForeignKey(name: "FK_TurnyroDalyvis_Komanda_KomandaID", table: "TurnyroDalyvis");
            migrationBuilder.DropForeignKey(name: "FK_TurnyroDalyvis_Turnyras_TurnyrasID", table: "TurnyroDalyvis");
            migrationBuilder.DropColumn(name: "VertiniusiuKiekis", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "Vidurkis", table: "AspNetUsers");
            migrationBuilder.DropTable("Vertinimas");
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserRenginys_ApplicationUser_ApplicationUserId",
                table: "UserRenginys",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserRenginys_Renginys_RenginysId",
                table: "UserRenginys",
                column: "RenginysId",
                principalTable: "Renginys",
                principalColumn: "RenginysID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_TurnyroDalyvis_Komanda_KomandaID",
                table: "TurnyroDalyvis",
                column: "KomandaID",
                principalTable: "Komanda",
                principalColumn: "KomandaID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_TurnyroDalyvis_Turnyras_TurnyrasID",
                table: "TurnyroDalyvis",
                column: "TurnyrasID",
                principalTable: "Turnyras",
                principalColumn: "TurnyrasID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
