using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVSeriesReviews.WPF.Migrations
{
    /// <inheritdoc />
    public partial class DateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "RegistrationDate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateWritten",
                table: "Reviews",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateWritten",
                table: "Reviews");
        }
    }
}
