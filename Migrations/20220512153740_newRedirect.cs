using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cbsStudents.Migrations
{
    public partial class newRedirect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUserClaim",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec135cf6-e017-48ea-8a08-3173208834e2", "AQAAAAEAACcQAAAAEFbJPCZlPkVtnUupjX3VBcaNEePrK8HF7ovzXQ7h2LfDABbuwsvJzxNoMEhNG6+iFA==", "bc38326f-d52e-404b-8bc4-f155f2590858" });

            migrationBuilder.UpdateData(
                table: "IdentityUserClaim",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32ba65aa-c268-4b0e-84f9-7f5c18cb9148", "AQAAAAEAACcQAAAAEGD7jrsyeka64mjvJTcn2jgXcEz2aIuyOGIHWWojcvPNuPorHjRDitGHwzjs2hBw+Q==", "0c3aef63-8347-4688-a828-f9e2f96a0a9d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUserClaim",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d959c2b2-832c-4223-8442-b8d14af64e89", "AQAAAAEAACcQAAAAEPoqCI2iZap49hoH52yN6cL791SdyACQgOML8L91QtnHbpf7PH+na00KZbnFSh0Z6w==", "91a86242-51a9-4688-9eac-b88192070dd4" });

            migrationBuilder.UpdateData(
                table: "IdentityUserClaim",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db239212-a406-4aba-bf1f-743a1a9d904f", "AQAAAAEAACcQAAAAEMDWhJoN/hQ+qGVBq/xkBwPJnjF73qTYoZZDpKmhR/GgbQuH78flPIz5Vs+m5w9eQw==", "e0049763-9074-4376-8af1-a2191df8fea5" });
        }
    }
}
