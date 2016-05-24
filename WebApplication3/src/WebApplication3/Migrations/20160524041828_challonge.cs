using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace WebApplication3.Migrations
{
    public partial class challonge : Migration
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
            migrationBuilder.DropForeignKey(name: "FK_TurnyroVarzybos_Aikstele_AiksteleAiksteleID", table: "TurnyroVarzybos");
            migrationBuilder.DropForeignKey(name: "FK_TurnyroVarzybos_Komanda_KomandaAKomandaID", table: "TurnyroVarzybos");
            migrationBuilder.DropForeignKey(name: "FK_TurnyroVarzybos_Komanda_KomandaBKomandaID", table: "TurnyroVarzybos");
            migrationBuilder.DropForeignKey(name: "FK_TurnyroVarzybos_Turnyras_TurnyrasTurnyrasID", table: "TurnyroVarzybos");
            migrationBuilder.DropColumn(name: "AiksteleAiksteleID", table: "TurnyroVarzybos");
            migrationBuilder.DropColumn(name: "KomandaAKomandaID", table: "TurnyroVarzybos");
            migrationBuilder.DropColumn(name: "KomandaBKomandaID", table: "TurnyroVarzybos");
            migrationBuilder.DropColumn(name: "TurnyrasTurnyrasID", table: "TurnyroVarzybos");
            migrationBuilder.AddColumn<string>(
                name: "AiksteleID",
                table: "TurnyroVarzybos",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "KomandaA_ID",
                table: "TurnyroVarzybos",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "KomandaB_ID",
                table: "TurnyroVarzybos",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "TurnyrasID",
                table: "TurnyroVarzybos",
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
            migrationBuilder.DropColumn(name: "AiksteleID", table: "TurnyroVarzybos");
            migrationBuilder.DropColumn(name: "KomandaA_ID", table: "TurnyroVarzybos");
            migrationBuilder.DropColumn(name: "KomandaB_ID", table: "TurnyroVarzybos");
            migrationBuilder.DropColumn(name: "TurnyrasID", table: "TurnyroVarzybos");
            migrationBuilder.AddColumn<string>(
                name: "AiksteleAiksteleID",
                table: "TurnyroVarzybos",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "KomandaAKomandaID",
                table: "TurnyroVarzybos",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "KomandaBKomandaID",
                table: "TurnyroVarzybos",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "TurnyrasTurnyrasID",
                table: "TurnyroVarzybos",
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
                name: "FK_TurnyroVarzybos_Aikstele_AiksteleAiksteleID",
                table: "TurnyroVarzybos",
                column: "AiksteleAiksteleID",
                principalTable: "Aikstele",
                principalColumn: "AiksteleID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_TurnyroVarzybos_Komanda_KomandaAKomandaID",
                table: "TurnyroVarzybos",
                column: "KomandaAKomandaID",
                principalTable: "Komanda",
                principalColumn: "KomandaID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_TurnyroVarzybos_Komanda_KomandaBKomandaID",
                table: "TurnyroVarzybos",
                column: "KomandaBKomandaID",
                principalTable: "Komanda",
                principalColumn: "KomandaID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_TurnyroVarzybos_Turnyras_TurnyrasTurnyrasID",
                table: "TurnyroVarzybos",
                column: "TurnyrasTurnyrasID",
                principalTable: "Turnyras",
                principalColumn: "TurnyrasID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
