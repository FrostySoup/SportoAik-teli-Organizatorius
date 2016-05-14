using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace WebApplication3.Migrations
{
    public partial class AiksteliuLtTaidziuSalinimas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_AikstelesKomentaras_Aikstele_aiksteleID", table: "AikstelesKomentaras");
            migrationBuilder.DropForeignKey(name: "FK_AikstelesVertinimas_Aikstele_aiksteleID", table: "AikstelesVertinimas");
            migrationBuilder.DropColumn(name: "ArPrasidėjo", table: "Renginys");
            migrationBuilder.DropColumn(name: "SportoŠaka", table: "Renginys");
            migrationBuilder.AddColumn<bool>(
                name: "ArPrasidejo",
                table: "Renginys",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<string>(
                name: "SportoSaka",
                table: "Renginys",
                nullable: false,
                defaultValue: "");
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
                name: "FK_AikstelesKomentaras_Aikstele_AiksteleID",
                table: "AikstelesKomentaras",
                column: "AiksteleID",
                principalTable: "Aikstele",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_AikstelesVertinimas_Aikstele_AiksteleID",
                table: "AikstelesVertinimas",
                column: "AiksteleID",
                principalTable: "Aikstele",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.RenameColumn(
                name: "renginioAutoriausID",
                table: "Renginys",
                newName: "RenginioAutoriausID");
            migrationBuilder.RenameColumn(
                name: "data",
                table: "Renginys",
                newName: "Data");
            migrationBuilder.RenameColumn(
                name: "vertinimas",
                table: "AikstelesVertinimas",
                newName: "Vertinimas");
            migrationBuilder.RenameColumn(
                name: "aiksteleID",
                table: "AikstelesVertinimas",
                newName: "AiksteleID");
            migrationBuilder.RenameColumn(
                name: "aiksteleID",
                table: "AikstelesKomentaras",
                newName: "AiksteleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_AikstelesKomentaras_Aikstele_AiksteleID", table: "AikstelesKomentaras");
            migrationBuilder.DropForeignKey(name: "FK_AikstelesVertinimas_Aikstele_AiksteleID", table: "AikstelesVertinimas");
            migrationBuilder.DropColumn(name: "ArPrasidejo", table: "Renginys");
            migrationBuilder.DropColumn(name: "SportoSaka", table: "Renginys");
            migrationBuilder.AddColumn<bool>(
                name: "ArPrasidėjo",
                table: "Renginys",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<string>(
                name: "SportoŠaka",
                table: "Renginys",
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
                name: "FK_AikstelesKomentaras_Aikstele_aiksteleID",
                table: "AikstelesKomentaras",
                column: "aiksteleID",
                principalTable: "Aikstele",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_AikstelesVertinimas_Aikstele_aiksteleID",
                table: "AikstelesVertinimas",
                column: "aiksteleID",
                principalTable: "Aikstele",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.RenameColumn(
                name: "RenginioAutoriausID",
                table: "Renginys",
                newName: "renginioAutoriausID");
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Renginys",
                newName: "data");
            migrationBuilder.RenameColumn(
                name: "Vertinimas",
                table: "AikstelesVertinimas",
                newName: "vertinimas");
            migrationBuilder.RenameColumn(
                name: "AiksteleID",
                table: "AikstelesVertinimas",
                newName: "aiksteleID");
            migrationBuilder.RenameColumn(
                name: "AiksteleID",
                table: "AikstelesKomentaras",
                newName: "aiksteleID");
        }
    }
}
