using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cbsStudents.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityUserClaim",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventName = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_IdentityUserClaim_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUserClaim",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_IdentityUserClaim_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUserClaim",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventComment",
                columns: table => new
                {
                    EventCommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventComment", x => x.EventCommentId);
                    table.ForeignKey(
                        name: "FK_EventComment_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventComment_IdentityUserClaim_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUserClaim",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_IdentityUserClaim_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUserClaim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IdentityUserClaim",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "d959c2b2-832c-4223-8442-b8d14af64e89", "chrk@kea.dk", true, false, null, null, null, "AQAAAAEAACcQAAAAEPoqCI2iZap49hoH52yN6cL791SdyACQgOML8L91QtnHbpf7PH+na00KZbnFSh0Z6w==", null, false, "91a86242-51a9-4688-9eac-b88192070dd4", false, "chrk@kea.dk" });

            migrationBuilder.InsertData(
                table: "IdentityUserClaim",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "db239212-a406-4aba-bf1f-743a1a9d904f", "test@kea.dk", true, false, null, null, null, "AQAAAAEAACcQAAAAEMDWhJoN/hQ+qGVBq/xkBwPJnjF73qTYoZZDpKmhR/GgbQuH78flPIz5Vs+m5w9eQw==", null, false, "e0049763-9074-4376-8af1-a2191df8fea5", false, "test@kea.dk" });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "Date", "EventName", "Location", "Status", "Text", "UserId" },
                values: new object[] { 20, new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fredags Bar", "Guldbar", 1, "Første fredags bar kom glad og kom tørstig", "1" });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "Date", "EventName", "Location", "Status", "Text", "UserId" },
                values: new object[] { 21, new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fredags Bar", "Guldbar", 1, "Anden fredags bar kom glad og kom tørstig", "1" });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "Date", "EventName", "Location", "Status", "Text", "UserId" },
                values: new object[] { 22, new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rustur", "Gilleleje Campingplads", 1, "Her kommer vi", "2" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Created", "Status", "Text", "Title", "UserId" },
                values: new object[] { 20, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "I'll be good waifu", "Happy wife happy life", "1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Created", "Status", "Text", "Title", "UserId" },
                values: new object[] { 22, new DateTime(2016, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "I'll be good waifu", "Marry me please desu", "1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Created", "Status", "Text", "Title", "UserId" },
                values: new object[] { 23, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "If you have seen the recent news you might realise that Hollywood is scary", "Johnny Deep is finally happy", "2" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "PostId", "Url", "UserId" },
                values: new object[] { 1, 20, "https://www.youtube.com/watch?v=XNwoowL2u24", "2" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "PostId", "Url", "UserId" },
                values: new object[] { 2, 22, "Lorem ipsum exvacatum", "2" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "PostId", "Url", "UserId" },
                values: new object[] { 3, 23, "Never say never", "2" });

            migrationBuilder.InsertData(
                table: "EventComment",
                columns: new[] { "EventCommentId", "EventId", "Text", "UserId" },
                values: new object[] { 1, 20, "Det bliver fedt", "1" });

            migrationBuilder.InsertData(
                table: "EventComment",
                columns: new[] { "EventCommentId", "EventId", "Text", "UserId" },
                values: new object[] { 2, 21, "Det bliver bedre end den første", "1" });

            migrationBuilder.InsertData(
                table: "EventComment",
                columns: new[] { "EventCommentId", "EventId", "Text", "UserId" },
                values: new object[] { 3, 20, "Det bliver mega fedt", "2" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_UserId",
                table: "Event",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventComment_EventId",
                table: "EventComment",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventComment_UserId",
                table: "EventComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "EventComment");

            migrationBuilder.DropTable(
                name: "IdentityUserClaim<string>");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "IdentityUserClaim");
        }
    }
}
