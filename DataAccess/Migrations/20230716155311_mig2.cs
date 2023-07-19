using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Titles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Titles_UserID",
                table: "Titles",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Users_UserID",
                table: "Titles",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Users_UserID",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_UserID",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Titles");
        }
    }
}
