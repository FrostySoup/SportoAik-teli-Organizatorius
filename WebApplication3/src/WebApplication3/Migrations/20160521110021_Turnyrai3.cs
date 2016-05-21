using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace WebApplication3.Migrations
{
    public partial class Turnyrai3 : Migration
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
            migrationBuilder.DropForeignKey(name: "FK_Komentaras_ApplicationUser_ApplicationUserId", table: "Komentaras");
            migrationBuilder.DropColumn(name: "ApplicationUserId", table: "Komentaras");
            migrationBuilder.AlterColumn<string>(
                name: "Pavadinimas",
                table: "Turnyras",
                nullable: false);
            migrationBuilder.AddColumn<DateTime>(
                name: "PrasidejimoData",
                table: "Turnyras",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<DateTime>(
                name: "SukurimoData",
                table: "Turnyras",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AikstelesKomentaras",
                nullable: true);
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
                name: "FK_AikstelesKomentaras_ApplicationUser_ApplicationUserId",
                table: "AikstelesKomentaras",
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
            migrationBuilder.AddForeignKey(
                name: "FK_Komentaras_ApplicationUser_userId",
                table: "Komentaras",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_AikstelesKomentaras_ApplicationUser_ApplicationUserId", table: "AikstelesKomentaras");
            migrationBuilder.DropForeignKey(name: "FK_UserRenginys_ApplicationUser_ApplicationUserId", table: "UserRenginys");
            migrationBuilder.DropForeignKey(name: "FK_UserRenginys_Renginys_RenginysId", table: "UserRenginys");
            migrationBuilder.DropForeignKey(name: "FK_TurnyroDalyvis_Komanda_KomandaID", table: "TurnyroDalyvis");
            migrationBuilder.DropForeignKey(name: "FK_TurnyroDalyvis_Turnyras_TurnyrasID", table: "TurnyroDalyvis");
            migrationBuilder.DropForeignKey(name: "FK_Komentaras_ApplicationUser_userId", table: "Komentaras");
            migrationBuilder.DropColumn(name: "PrasidejimoData", table: "Turnyras");
            migrationBuilder.DropColumn(name: "SukurimoData", table: "Turnyras");
            migrationBuilder.DropColumn(name: "ApplicationUserId", table: "AikstelesKomentaras");
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Komentaras",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "Pavadinimas",
                table: "Turnyras",
                nullable: true);
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
            migrationBuilder.AddForeignKey(
                name: "FK_Komentaras_ApplicationUser_ApplicationUserId",
                table: "Komentaras",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
