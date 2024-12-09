﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PerformanceTrackingService.Data;

#nullable disable

namespace PerformanceTrackingService.Migrations
{
    [DbContext(typeof(PerformanceContext))]
    [Migration("20241209060654_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PerformanceTrackingService.Models.PerformanceStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int>("GoalsScored")
                        .HasColumnType("int");

                    b.Property<int>("MatchesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PerformanceStats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Assists = 0,
                            GoalsScored = 0,
                            MatchesPlayed = 0,
                            PlayerId = 101
                        },
                        new
                        {
                            Id = 2,
                            Assists = 0,
                            GoalsScored = 0,
                            MatchesPlayed = 0,
                            PlayerId = 102
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
