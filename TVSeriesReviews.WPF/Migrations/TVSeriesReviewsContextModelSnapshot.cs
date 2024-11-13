﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TVSeriesReviews.WPF.Models.Data;

#nullable disable

namespace TVSeriesReviews.WPF.Migrations
{
    [DbContext(typeof(TVSeriesReviewsContext))]
    partial class TVSeriesReviewsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int?>("SeasonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Rate")
                        .HasColumnType("integer");

                    b.Property<int?>("TVShowId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Users_Rate")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TVShowId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.ReviewLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsLike")
                        .HasColumnType("boolean");

                    b.Property<int?>("ReviewId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("ReviewLikes");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int?>("TVShowId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TVShowId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.TVShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("PosterPath")
                        .HasColumnType("text");

                    b.Property<decimal>("Rate")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TVShows");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.TVShowActor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActorId")
                        .HasColumnType("integer");

                    b.Property<int?>("TVShowId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("TVShowId");

                    b.ToTable("TVShowActors");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.TVShowDirector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DirectorId")
                        .HasColumnType("integer");

                    b.Property<int?>("TVShowId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("TVShowId");

                    b.ToTable("TVShowDirectors");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.TVShowGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int?>("TVShowId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("TVShowId");

                    b.ToTable("TVShowGenres");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.UserTVShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("TVShowId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TVShowId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTVShows");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.Episode", b =>
                {
                    b.HasOne("TVSeriesReviews.WPF.Models.Season", "Season")
                        .WithMany("Episodes")
                        .HasForeignKey("SeasonId");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.Review", b =>
                {
                    b.HasOne("TVSeriesReviews.WPF.Models.TVShow", "TVShow")
                        .WithMany("Reviews")
                        .HasForeignKey("TVShowId");

                    b.HasOne("TVSeriesReviews.WPF.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");

                    b.Navigation("TVShow");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.ReviewLike", b =>
                {
                    b.HasOne("TVSeriesReviews.WPF.Models.Review", "Review")
                        .WithMany("ReviewLikes")
                        .HasForeignKey("ReviewId");

                    b.HasOne("TVSeriesReviews.WPF.Models.User", "User")
                        .WithMany("ReviewLikes")
                        .HasForeignKey("UserId");

                    b.Navigation("Review");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.Season", b =>
                {
                    b.HasOne("TVSeriesReviews.WPF.Models.TVShow", "TVShow")
                        .WithMany("Seasons")
                        .HasForeignKey("TVShowId");

                    b.Navigation("TVShow");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.TVShowActor", b =>
                {
                    b.HasOne("TVSeriesReviews.WPF.Models.Actor", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId");

                    b.HasOne("TVSeriesReviews.WPF.Models.TVShow", "TVShow")
                        .WithMany("TVShowActors")
                        .HasForeignKey("TVShowId");

                    b.Navigation("Actor");

                    b.Navigation("TVShow");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.TVShowDirector", b =>
                {
                    b.HasOne("TVSeriesReviews.WPF.Models.Director", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId");

                    b.HasOne("TVSeriesReviews.WPF.Models.TVShow", "TVShow")
                        .WithMany("TVShowDirectors")
                        .HasForeignKey("TVShowId");

                    b.Navigation("Director");

                    b.Navigation("TVShow");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.TVShowGenre", b =>
                {
                    b.HasOne("TVSeriesReviews.WPF.Models.Genre", "Genre")
                        .WithMany("TVShowGenres")
                        .HasForeignKey("GenreId");

                    b.HasOne("TVSeriesReviews.WPF.Models.TVShow", "TVShow")
                        .WithMany("TVShowGenres")
                        .HasForeignKey("TVShowId");

                    b.Navigation("Genre");

                    b.Navigation("TVShow");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.UserTVShow", b =>
                {
                    b.HasOne("TVSeriesReviews.WPF.Models.TVShow", "TVShow")
                        .WithMany()
                        .HasForeignKey("TVShowId");

                    b.HasOne("TVSeriesReviews.WPF.Models.User", "User")
                        .WithMany("Watchlist")
                        .HasForeignKey("UserId");

                    b.Navigation("TVShow");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.Genre", b =>
                {
                    b.Navigation("TVShowGenres");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.Review", b =>
                {
                    b.Navigation("ReviewLikes");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.Season", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.TVShow", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Seasons");

                    b.Navigation("TVShowActors");

                    b.Navigation("TVShowDirectors");

                    b.Navigation("TVShowGenres");
                });

            modelBuilder.Entity("TVSeriesReviews.WPF.Models.User", b =>
                {
                    b.Navigation("ReviewLikes");

                    b.Navigation("Reviews");

                    b.Navigation("Watchlist");
                });
#pragma warning restore 612, 618
        }
    }
}
