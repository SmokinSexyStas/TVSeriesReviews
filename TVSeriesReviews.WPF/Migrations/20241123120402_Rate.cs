using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVSeriesReviews.WPF.Migrations
{
    /// <inheritdoc />
    public partial class Rate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "TVShows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "TVShows");
        }
    }
}
