using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace WebApplication3.Migrations
{
    public partial class IdSutvarkymas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_AikstelesKomentaras_Aikstele_AiksteleID", table: "AikstelesKomentaras");
            migrationBuilder.DropForeignKey(name: "FK_AikstelesVertinimas_Aikstele_AiksteleID", table: "AikstelesVertinimas");
            migrationBuilder.DropForeignKey(name: "FK_Renginys_Aikstele_AiksteleID", table: "Renginys");
            migrationBuilder.DropPrimaryKey(name: "PK_Renginys", table: "Renginys");
            migrationBuilder.DropPrimaryKey(name: "PK_AikstelesVertinimas", table: "AikstelesVertinimas");
            migrationBuilder.DropPrimaryKey(name: "PK_AikstelesKomentaras", table: "AikstelesKomentaras");
            migrationBuilder.DropPrimaryKey(name: "PK_Aikstele", table: "Aikstele");
            migrationBuilder.DropColumn(name: "ID", table: "Renginys");
            migrationBuilder.DropColumn(name: "AiksteleID", table: "Renginys");
            migrationBuilder.DropColumn(name: "ID", table: "AikstelesVertinimas");
            migrationBuilder.DropColumn(name: "AiksteleID", table: "AikstelesVertinimas");
            migrationBuilder.DropColumn(name: "ID", table: "AikstelesKomentaras");
            migrationBuilder.DropColumn(name: "AiksteleID", table: "AikstelesKomentaras");
            migrationBuilder.DropColumn(name: "ID", table: "Aikstele");
            migrationBuilder.AddColumn<string>(
                name: "RenginysID",
                table: "Renginys",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddColumn<string>(
                name: "AiksteleAiksteleID",
                table: "Renginys",
                nullable: true);
            migrationBuilder.AddPrimaryKey(
                name: "PK_Renginys",
                table: "Renginys",
                column: "RenginysID");
            migrationBuilder.AddColumn<string>(
                name: "AikstelesVertinimasID",
                table: "AikstelesVertinimas",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddColumn<string>(
                name: "AiksteleAiksteleID",
                table: "AikstelesVertinimas",
                nullable: true);
            migrationBuilder.AddPrimaryKey(
                name: "PK_AikstelesVertinimas",
                table: "AikstelesVertinimas",
                column: "AikstelesVertinimasID");
            migrationBuilder.AddColumn<string>(
                name: "AikstelesKomentarasID",
                table: "AikstelesKomentaras",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddColumn<string>(
                name: "AiksteleAiksteleID",
                table: "AikstelesKomentaras",
                nullable: true);
            migrationBuilder.AddPrimaryKey(
                name: "PK_AikstelesKomentaras",
                table: "AikstelesKomentaras",
                column: "AikstelesKomentarasID");
            migrationBuilder.AddColumn<string>(
                name: "AiksteleID",
                table: "Aikstele",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddPrimaryKey(
                name: "PK_Aikstele",
                table: "Aikstele",
                column: "AiksteleID");
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
                name: "FK_AikstelesKomentaras_Aikstele_AiksteleAiksteleID",
                table: "AikstelesKomentaras",
                column: "AiksteleAiksteleID",
                principalTable: "Aikstele",
                principalColumn: "AiksteleID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_AikstelesVertinimas_Aikstele_AiksteleAiksteleID",
                table: "AikstelesVertinimas",
                column: "AiksteleAiksteleID",
                principalTable: "Aikstele",
                principalColumn: "AiksteleID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Renginys_Aikstele_AiksteleAiksteleID",
                table: "Renginys",
                column: "AiksteleAiksteleID",
                principalTable: "Aikstele",
                principalColumn: "AiksteleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_AikstelesKomentaras_Aikstele_AiksteleAiksteleID", table: "AikstelesKomentaras");
            migrationBuilder.DropForeignKey(name: "FK_AikstelesVertinimas_Aikstele_AiksteleAiksteleID", table: "AikstelesVertinimas");
            migrationBuilder.DropForeignKey(name: "FK_Renginys_Aikstele_AiksteleAiksteleID", table: "Renginys");
            migrationBuilder.DropPrimaryKey(name: "PK_Renginys", table: "Renginys");
            migrationBuilder.DropPrimaryKey(name: "PK_AikstelesVertinimas", table: "AikstelesVertinimas");
            migrationBuilder.DropPrimaryKey(name: "PK_AikstelesKomentaras", table: "AikstelesKomentaras");
            migrationBuilder.DropPrimaryKey(name: "PK_Aikstele", table: "Aikstele");
            migrationBuilder.DropColumn(name: "RenginysID", table: "Renginys");
            migrationBuilder.DropColumn(name: "AiksteleAiksteleID", table: "Renginys");
            migrationBuilder.DropColumn(name: "AikstelesVertinimasID", table: "AikstelesVertinimas");
            migrationBuilder.DropColumn(name: "AiksteleAiksteleID", table: "AikstelesVertinimas");
            migrationBuilder.DropColumn(name: "AikstelesKomentarasID", table: "AikstelesKomentaras");
            migrationBuilder.DropColumn(name: "AiksteleAiksteleID", table: "AikstelesKomentaras");
            migrationBuilder.DropColumn(name: "AiksteleID", table: "Aikstele");
            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "Renginys",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddColumn<string>(
                name: "AiksteleID",
                table: "Renginys",
                nullable: true);
            migrationBuilder.AddPrimaryKey(
                name: "PK_Renginys",
                table: "Renginys",
                column: "ID");
            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "AikstelesVertinimas",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddColumn<string>(
                name: "AiksteleID",
                table: "AikstelesVertinimas",
                nullable: true);
            migrationBuilder.AddPrimaryKey(
                name: "PK_AikstelesVertinimas",
                table: "AikstelesVertinimas",
                column: "ID");
            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "AikstelesKomentaras",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddColumn<string>(
                name: "AiksteleID",
                table: "AikstelesKomentaras",
                nullable: true);
            migrationBuilder.AddPrimaryKey(
                name: "PK_AikstelesKomentaras",
                table: "AikstelesKomentaras",
                column: "ID");
            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "Aikstele",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddPrimaryKey(
                name: "PK_Aikstele",
                table: "Aikstele",
                column: "ID");
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
            migrationBuilder.AddForeignKey(
                name: "FK_Renginys_Aikstele_AiksteleID",
                table: "Renginys",
                column: "AiksteleID",
                principalTable: "Aikstele",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
