﻿// <auto-generated />
using System;
using EntFrmLab2.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntFrmLab2.DAL.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240304202942_ICollectionToList1")]
    partial class ICollectionToList1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntFrmLab2.DAL.Models.GoalScorer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GoalsScored")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GoalScorers");
                });

            modelBuilder.Entity("EntFrmLab2.DAL.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GoalsTeam1")
                        .HasColumnType("int");

                    b.Property<int>("GoalsTeam2")
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Team1Idid")
                        .HasColumnType("int");

                    b.Property<int>("Team2Idid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Team1Idid");

                    b.HasIndex("Team2Idid");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("EntFrmLab2.DAL.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JerseyNumber")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("EntFrmLab2.DAL.Models.Team", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("GameLoss")
                        .HasColumnType("int");

                    b.Property<int>("GameTie")
                        .HasColumnType("int");

                    b.Property<int>("GameWin")
                        .HasColumnType("int");

                    b.Property<int>("MissedHeads")
                        .HasColumnType("int");

                    b.Property<int>("ScoredGoals")
                        .HasColumnType("int");

                    b.Property<string>("TeamCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("EntFrmLab2.DAL.Models.GoalScorer", b =>
                {
                    b.HasOne("EntFrmLab2.DAL.Models.Match", "Match")
                        .WithMany("GoalScorers")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntFrmLab2.DAL.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("EntFrmLab2.DAL.Models.Match", b =>
                {
                    b.HasOne("EntFrmLab2.DAL.Models.Team", "Team1Id")
                        .WithMany()
                        .HasForeignKey("Team1Idid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EntFrmLab2.DAL.Models.Team", "Team2Id")
                        .WithMany()
                        .HasForeignKey("Team2Idid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Team1Id");

                    b.Navigation("Team2Id");
                });

            modelBuilder.Entity("EntFrmLab2.DAL.Models.Player", b =>
                {
                    b.HasOne("EntFrmLab2.DAL.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("EntFrmLab2.DAL.Models.Match", b =>
                {
                    b.Navigation("GoalScorers");
                });

            modelBuilder.Entity("EntFrmLab2.DAL.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
