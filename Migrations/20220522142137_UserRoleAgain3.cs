using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cbsStudents.Migrations
{
    public partial class UserRoleAgain3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_IdentityUserClaim_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_IdentityUserClaim_UserId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventComment_IdentityUserClaim_UserId",
                table: "EventComment");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_IdentityUserClaim_UserId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserClaim<string>",
                table: "IdentityUserClaim<string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserClaim",
                table: "IdentityUserClaim");

            migrationBuilder.RenameTable(
                name: "IdentityUserClaim<string>",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "IdentityUserClaim",
                newName: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1219972-59ba-46c4-91a0-c104359213f6", "AQAAAAEAACcQAAAAEEBsXJfQZOfEUAS3u8FW4GfepfkMx6fo+IsHZbqV7AfEKEpXf1U9Ipg6MyNPLeinSw==", "f4da85ef-cc24-4af2-b6c9-2328c87ff529" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89d0c221-9856-4d50-8391-2e52096e9737", "AQAAAAEAACcQAAAAECcjNMfTkyoF8rJ2Fsup3tpdaiSGEkqzR5Hu5+IMj6ZUzuRyHKZN50IKJ1XXLIOGvA==", "e21c1257-db66-44fd-98a0-7948986ee9f5" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_AspNetUsers_UserId",
                table: "Event",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventComment_AspNetUsers_UserId",
                table: "EventComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_AspNetUsers_UserId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventComment_AspNetUsers_UserId",
                table: "EventComment");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "IdentityUserClaim");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "IdentityUserClaim<string>");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "IdentityUserClaim<string>",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserClaim",
                table: "IdentityUserClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserClaim<string>",
                table: "IdentityUserClaim<string>",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_IdentityUserClaim_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "IdentityUserClaim",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_IdentityUserClaim_UserId",
                table: "Event",
                column: "UserId",
                principalTable: "IdentityUserClaim",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventComment_IdentityUserClaim_UserId",
                table: "EventComment",
                column: "UserId",
                principalTable: "IdentityUserClaim",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_IdentityUserClaim_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "IdentityUserClaim",
                principalColumn: "Id");
        }
    }
}
