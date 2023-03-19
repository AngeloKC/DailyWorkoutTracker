﻿// <auto-generated />
using System;
using DailyWorkoutTracker.ResourceAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DailyWorkoutTracker.ResourceAccess.Migrations
{
    [DbContext(typeof(DailyWorkoutTrackerContext))]
    [Migration("20230319180722_Removing2WayRelationship3")]
    partial class Removing2WayRelationship3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.ExerciseCategory", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExerciseId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ExerciseCategory");
                });

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.ExerciseEquipment", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExerciseId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("ExerciseEquipments");
                });

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.ExerciseMuscleGroup", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MuscleGroupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExerciseId", "MuscleGroupId");

                    b.HasIndex("MuscleGroupId");

                    b.ToTable("ExerciseMuscleGroups");
                });

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.MuscleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MuscleGroups");
                });

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.ExerciseCategory", b =>
                {
                    b.HasOne("DailyWorkoutTracker.ResourceAccess.Models.Category", "Category")
                        .WithMany("ExerciseCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DailyWorkoutTracker.ResourceAccess.Models.Exercise", "Exercise")
                        .WithMany("ExerciseCategories")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.ExerciseEquipment", b =>
                {
                    b.HasOne("DailyWorkoutTracker.ResourceAccess.Models.Equipment", "Equipment")
                        .WithMany("ExerciseEquipments")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DailyWorkoutTracker.ResourceAccess.Models.Exercise", "Exercise")
                        .WithMany("ExerciseEquipments")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.ExerciseMuscleGroup", b =>
                {
                    b.HasOne("DailyWorkoutTracker.ResourceAccess.Models.Exercise", "Exercise")
                        .WithMany("ExerciseMuscleGroups")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DailyWorkoutTracker.ResourceAccess.Models.MuscleGroup", "MuscleGroup")
                        .WithMany("ExerciseMuscleGroups")
                        .HasForeignKey("MuscleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("MuscleGroup");
                });

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.Category", b =>
                {
                    b.Navigation("ExerciseCategories");
                });

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.Equipment", b =>
                {
                    b.Navigation("ExerciseEquipments");
                });

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.Exercise", b =>
                {
                    b.Navigation("ExerciseCategories");

                    b.Navigation("ExerciseEquipments");

                    b.Navigation("ExerciseMuscleGroups");
                });

            modelBuilder.Entity("DailyWorkoutTracker.ResourceAccess.Models.MuscleGroup", b =>
                {
                    b.Navigation("ExerciseMuscleGroups");
                });
#pragma warning restore 612, 618
        }
    }
}