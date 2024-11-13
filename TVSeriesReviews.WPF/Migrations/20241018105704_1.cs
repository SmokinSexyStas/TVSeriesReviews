using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TVSeriesReviews.WPF.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewLikes_User_UserId",
                table: "ReviewLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_User_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShows_User_UserId",
                table: "TVShows");

            migrationBuilder.DropIndex(
                name: "IX_TVShows_UserId",
                table: "TVShows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "Id_Genre",
                table: "TVShowGenres");

            migrationBuilder.DropColumn(
                name: "Id_TVShow",
                table: "TVShowGenres");

            migrationBuilder.DropColumn(
                name: "Id_Director",
                table: "TVShowDirectors");

            migrationBuilder.DropColumn(
                name: "Id_TVShow",
                table: "TVShowDirectors");

            migrationBuilder.DropColumn(
                name: "Id_Actor",
                table: "TVShowActors");

            migrationBuilder.DropColumn(
                name: "Id_TVShow",
                table: "TVShowActors");

            migrationBuilder.DropColumn(
                name: "Id_TVShow",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "Id_TVShow",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Id_User",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Id_Review",
                table: "ReviewLikes");

            migrationBuilder.DropColumn(
                name: "Id_User",
                table: "ReviewLikes");

            migrationBuilder.DropColumn(
                name: "Id_Season",
                table: "Episodes");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserTVShows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    TVShowId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTVShows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTVShows_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTVShows_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTVShows_TVShowId",
                table: "UserTVShows",
                column: "TVShowId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTVShows_UserId",
                table: "UserTVShows",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewLikes_Users_UserId",
                table: "ReviewLikes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewLikes_Users_UserId",
                table: "ReviewLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "UserTVShows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TVShows",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Genre",
                table: "TVShowGenres",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_TVShow",
                table: "TVShowGenres",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Director",
                table: "TVShowDirectors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_TVShow",
                table: "TVShowDirectors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Actor",
                table: "TVShowActors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_TVShow",
                table: "TVShowActors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_TVShow",
                table: "Seasons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_TVShow",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_User",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Review",
                table: "ReviewLikes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_User",
                table: "ReviewLikes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Season",
                table: "Episodes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TVShows_UserId",
                table: "TVShows",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewLikes_User_UserId",
                table: "ReviewLikes",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_User_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TVShows_User_UserId",
                table: "TVShows",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
