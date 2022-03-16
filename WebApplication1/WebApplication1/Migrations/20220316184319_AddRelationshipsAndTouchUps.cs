using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddRelationshipsAndTouchUps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnedJournalId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    JournalNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.JournalNumber);
                    table.ForeignKey(
                        name: "FK_Journal_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJournal",
                columns: table => new
                {
                    EditingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JournalNumber = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_User_OwnedJournalId",
                table: "User",
                column: "OwnedJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_Journal_OwnerId",
                table: "Journal",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJournal_JournalNumber",
                table: "UserJournal",
                column: "JournalNumber");

            migrationBuilder.CreateIndex(
                name: "IX_UserJournal_UserId",
                table: "UserJournal",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Journal_OwnedJournalId",
                table: "User",
                column: "OwnedJournalId",
                principalTable: "Journal",
                principalColumn: "JournalNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Journal_OwnedJournalId",
                table: "User");

            migrationBuilder.DropTable(
                name: "UserJournal");

            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.DropIndex(
                name: "IX_User_OwnedJournalId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "OwnedJournalId",
                table: "User");
        }
    }
}
