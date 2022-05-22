using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cbsStudents.Migrations
{
    public partial class UserRoleAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUserClaim",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04054166-6868-442f-bdb0-9070b943dae5", "AQAAAAEAACcQAAAAEIda4LVhVi1sOIVcNeJZ1BXEMk+mOvH136xo1RbnqYtiE/pB86X4O0uV9UPPsEm3oQ==", "f78419d1-310a-4531-85f9-1cb916c8b0d2" });

            migrationBuilder.UpdateData(
                table: "IdentityUserClaim",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2202bc70-b5cc-48e2-9b1f-b098da280b55", "AQAAAAEAACcQAAAAEAkwUdo+i/ixdGIedo85BLBpm2J49TUyXXS9gqDqdEOfsveO6b8BF/o06wZBGDZIGA==", "1320eb5b-dc24-406b-84d1-80417a6f2cd3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUserClaim",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2353b7a-ea46-4e35-bf48-41da364fc4fd", "AQAAAAEAACcQAAAAEI4OnhUu6x4iFLaIvVqb3cnItgomSyoyd8mItNuhs1dUe4EA09qH4bV0JZy9HCMsUw==", "b48aa3d2-455a-4c4a-9173-72bbcc9adb49" });

            migrationBuilder.UpdateData(
                table: "IdentityUserClaim",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd3e94ab-8ebd-4401-ba4a-093a80a0d4bf", "AQAAAAEAACcQAAAAEJbCZXakQujDcFFHNmucBNcfumc4JQtJpOkmkOZLIutixh3x8Y+5QhmCda6vJVObWQ==", "e5af8775-0066-4f30-8af6-428fc55106bf" });
        }
    }
}
