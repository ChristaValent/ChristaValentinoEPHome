using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PollModelFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Option3Votes",
                table: "Polls",
                newName: "Option3VotesCount");

            migrationBuilder.RenameColumn(
                name: "Option2Votes",
                table: "Polls",
                newName: "Option2VotesCount");

            migrationBuilder.RenameColumn(
                name: "Option1Votes",
                table: "Polls",
                newName: "Option1VotesCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Option3VotesCount",
                table: "Polls",
                newName: "Option3Votes");

            migrationBuilder.RenameColumn(
                name: "Option2VotesCount",
                table: "Polls",
                newName: "Option2Votes");

            migrationBuilder.RenameColumn(
                name: "Option1VotesCount",
                table: "Polls",
                newName: "Option1Votes");
        }
    }
}
