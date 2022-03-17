using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class startFromScratch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journal_User_OwnerId",
                table: "Journal");

            migrationBuilder.DropTable(
                name: "UserJournal");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Journal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    JournalNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.JournalNumber);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnedJournalId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Journal_OwnedJournalId",
                        column: x => x.OwnedJournalId,
                        principalTable: "Journal",
                        principalColumn: "JournalNumber");
                });

            migrationBuilder.CreateTable(
                name: "UserJournal",
                columns: table => new
                {
                    EditingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalNumber = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJournal", x => x.EditingId);
                    table.ForeignKey(
                        name: "FK_UserJournal_Journal_JournalNumber",
                        column: x => x.JournalNumber,
                        principalTable: "Journal",
                        principalColumn: "JournalNumber");
                    table.ForeignKey(
                        name: "FK_UserJournal_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "OwnedJournalId" },
                values: new object[] { 1, "Zach", "Montreuil", null });

            migrationBuilder.CreateIndex(
                name: "IX_Journal_OwnerId",
                table: "Journal",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_User_OwnedJournalId",
                table: "User",
                column: "OwnedJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJournal_JournalNumber",
                table: "UserJournal",
                column: "JournalNumber");

            migrationBuilder.CreateIndex(
                name: "IX_UserJournal_UserId",
                table: "UserJournal",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Journal_User_OwnerId",
                table: "Journal",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
