﻿// <auto-generated />
using Learner.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Learner.Persistence.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20240624141027_singleFactExercise")]
    partial class singleFactExercise
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Learner.Domain.Models.Exercise", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Learner.Domain.Models.FactInObject", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdditionalTags")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactObjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FactType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FactObjectId");

                    b.ToTable("Facts");
                });

            modelBuilder.Entity("Learner.Domain.Models.FactObject", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ExerciseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("FactObjects");
                });

            modelBuilder.Entity("Learner.Domain.Models.SingleFact", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdditionalTags")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SingleFactExerciseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SingleFactExerciseId");

                    b.ToTable("SingleFacts");
                });

            modelBuilder.Entity("Learner.Domain.Models.SingleFactExercise", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SingleFactExercises");
                });

            modelBuilder.Entity("Learner.Domain.Models.FactInObject", b =>
                {
                    b.HasOne("Learner.Domain.Models.FactObject", "FactObject")
                        .WithMany("Facts")
                        .HasForeignKey("FactObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FactObject");
                });

            modelBuilder.Entity("Learner.Domain.Models.FactObject", b =>
                {
                    b.HasOne("Learner.Domain.Models.Exercise", "Exercise")
                        .WithMany("FactObjects")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("Learner.Domain.Models.SingleFact", b =>
                {
                    b.HasOne("Learner.Domain.Models.SingleFactExercise", "SingleFactExercise")
                        .WithMany("Facts")
                        .HasForeignKey("SingleFactExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SingleFactExercise");
                });

            modelBuilder.Entity("Learner.Domain.Models.Exercise", b =>
                {
                    b.Navigation("FactObjects");
                });

            modelBuilder.Entity("Learner.Domain.Models.FactObject", b =>
                {
                    b.Navigation("Facts");
                });

            modelBuilder.Entity("Learner.Domain.Models.SingleFactExercise", b =>
                {
                    b.Navigation("Facts");
                });
#pragma warning restore 612, 618
        }
    }
}
