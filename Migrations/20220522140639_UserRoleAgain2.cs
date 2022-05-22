using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cbsStudents.Migrations
{
    public partial class UserRoleAgain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUserClaim",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb3c1a83-c1c5-4952-a29d-337513e7fbb5", "AQAAAAEAACcQAAAAEPS8vIlks8QI6UjuNZwo3oK9+iadDe2nU2RLsDncHyb6Va4q9Xj/2lLg5CGnTMD1GQ==", "89743672-bf8b-4bd2-bd60-aa8db12e4d74" });

            migrationBuilder.UpdateData(
                table: "IdentityUserClaim",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f518ee56-14cf-4270-8b47-66f330ec9658", "AQAAAAEAACcQAAAAEL/3fljqafktn23GD8/ALyX3q3jMO9i+8tjxYNyHhbiQvCpKjczzQCN89Vz7Guwkvw==", "b06977b8-e11d-470c-b21f-e2535c9afaf8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
