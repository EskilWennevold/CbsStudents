using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cbsStudents.Migrations
{
    public partial class CreateIdentityKode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "IdentityUserClaim",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "IdentityUserClaim",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "IdentityUserClaim",
                newName: "PhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "IdentityUserClaim",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "IdentityUserClaim",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "IdentityUserClaim",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "IdentityUserClaim",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "IdentityUserClaim",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "IdentityUserClaim",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "IdentityUserClaim",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "IdentityUserClaim",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "IdentityUserClaim",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "IdentityUserClaim",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "IdentityUserClaim",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "IdentityUserClaim",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim<string>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserClaim<string>");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "IdentityUserClaim");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "IdentityUserClaim");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "IdentityUserClaim");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "IdentityUserClaim");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "IdentityUserClaim");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "IdentityUserClaim");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "IdentityUserClaim");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "IdentityUserClaim");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "IdentityUserClaim");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "IdentityUserClaim");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "IdentityUserClaim");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "IdentityUserClaim",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "IdentityUserClaim",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "IdentityUserClaim",
                newName: "ClaimType");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "IdentityUserClaim",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
