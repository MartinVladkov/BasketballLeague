﻿// <auto-generated />
using BasketballLeague.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BasketballLeague.API.Migrations
{
    [DbContext(typeof(BasketballLeagueDbContext))]
    [Migration("20221207095026_spGetTeamsOponentsScore")]
    partial class spGetTeamsOponentsScore
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BasketballLeague.API.Data.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("awayTeamId")
                        .HasColumnType("int");

                    b.Property<int>("awayTeamScore")
                        .HasColumnType("int");

                    b.Property<int>("homeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("homeTeamScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("awayTeamId");

                    b.HasIndex("homeTeamId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BasketballLeague.API.Data.Models.TeamScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("totalScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TeamsScores", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("BasketballLeague.API.Data.Models.TeamsGames", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("awayTeam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("awayTeamScore")
                        .HasColumnType("int");

                    b.Property<string>("homeTeam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("homeTeamScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TeamsGames", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("BasketballLeague.API.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("BasketballLeague.API.Data.Models.Game", b =>
                {
                    b.HasOne("BasketballLeague.API.Team", "awayTeam")
                        .WithMany("awayGames")
                        .HasForeignKey("awayTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BasketballLeague.API.Team", "homeTeam")
                        .WithMany("homeGames")
                        .HasForeignKey("homeTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("awayTeam");

                    b.Navigation("homeTeam");
                });

            modelBuilder.Entity("BasketballLeague.API.Team", b =>
                {
                    b.Navigation("awayGames");

                    b.Navigation("homeGames");
                });
#pragma warning restore 612, 618
        }
    }
}
