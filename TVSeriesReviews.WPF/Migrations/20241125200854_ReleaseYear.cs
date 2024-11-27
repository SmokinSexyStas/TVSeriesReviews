using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVSeriesReviews.WPF.Migrations
{
    /// <inheritdoc />
    public partial class ReleaseYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "TVShows",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "TVShows");
        }
    }
}
