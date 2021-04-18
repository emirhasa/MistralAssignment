﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MistralAssignment.Database;

namespace MistralAssignment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MistralAssignment.Database.Actor", b =>
                {
                    b.Property<long>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("MistralAssignment.Database.Rating", b =>
                {
                    b.Property<long>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Grade")
                        .HasColumnType("tinyint");

                    b.Property<long>("ShowId")
                        .HasColumnType("bigint");

                    b.HasKey("RatingId");

                    b.HasIndex("ShowId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("MistralAssignment.Database.Show", b =>
                {
                    b.Property<long>("ShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AverageRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfRatings")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("ShowImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<short>("ShowTypeId")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShowId");

                    b.HasIndex("ShowTypeId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("MistralAssignment.Database.ShowActor", b =>
                {
                    b.Property<long>("ShowId")
                        .HasColumnType("bigint");

                    b.Property<long>("ActorId")
                        .HasColumnType("bigint");

                    b.HasKey("ShowId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("ShowActors");
                });

            modelBuilder.Entity("MistralAssignment.Database.ShowType", b =>
                {
                    b.Property<short>("ShowTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShowTypeId");

                    b.ToTable("ShowTypes");
                });

            modelBuilder.Entity("MistralAssignment.Database.Rating", b =>
                {
                    b.HasOne("MistralAssignment.Database.Show", "Show")
                        .WithMany("Ratings")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");
                });

            modelBuilder.Entity("MistralAssignment.Database.Show", b =>
                {
                    b.HasOne("MistralAssignment.Database.ShowType", "ShowType")
                        .WithMany()
                        .HasForeignKey("ShowTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShowType");
                });

            modelBuilder.Entity("MistralAssignment.Database.ShowActor", b =>
                {
                    b.HasOne("MistralAssignment.Database.Actor", "Actor")
                        .WithMany("ActorShows")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MistralAssignment.Database.Show", "Show")
                        .WithMany("Cast")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Show");
                });

            modelBuilder.Entity("MistralAssignment.Database.Actor", b =>
                {
                    b.Navigation("ActorShows");
                });

            modelBuilder.Entity("MistralAssignment.Database.Show", b =>
                {
                    b.Navigation("Cast");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
