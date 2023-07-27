using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TitleQuestionAdd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleQuestion_Titles_TitleID",
                table: "TitleQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TitleQuestion",
                table: "TitleQuestion");

            migrationBuilder.RenameTable(
                name: "TitleQuestion",
                newName: "TitleQuestions");

            migrationBuilder.RenameIndex(
                name: "IX_TitleQuestion_TitleID",
                table: "TitleQuestions",
                newName: "IX_TitleQuestions_TitleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TitleQuestions",
                table: "TitleQuestions",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TitleQuestions_Titles_TitleID",
                table: "TitleQuestions",
                column: "TitleID",
                principalTable: "Titles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleQuestions_Titles_TitleID",
                table: "TitleQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TitleQuestions",
                table: "TitleQuestions");

            migrationBuilder.RenameTable(
                name: "TitleQuestions",
                newName: "TitleQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_TitleQuestions_TitleID",
                table: "TitleQuestion",
                newName: "IX_TitleQuestion_TitleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TitleQuestion",
                table: "TitleQuestion",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TitleQuestion_Titles_TitleID",
                table: "TitleQuestion",
                column: "TitleID",
                principalTable: "Titles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
