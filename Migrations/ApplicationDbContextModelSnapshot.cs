﻿// <auto-generated />
using System;
using CalisthenicsRoutineTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CalisthenicsRoutineTracker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CalisthenicsRoutineTracker.Models.Date", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("date");
                });

            modelBuilder.Entity("CalisthenicsRoutineTracker.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DateId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("set1_reps")
                        .HasColumnType("int");

                    b.Property<int>("set2_reps")
                        .HasColumnType("int");

                    b.Property<int>("set3_reps")
                        .HasColumnType("int");

                    b.Property<int>("set4_reps")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DateId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("CalisthenicsRoutineTracker.Models.Workout", b =>
                {
                    b.HasOne("CalisthenicsRoutineTracker.Models.Date", null)
                        .WithMany("workouts")
                        .HasForeignKey("DateId");
                });

            modelBuilder.Entity("CalisthenicsRoutineTracker.Models.Date", b =>
                {
                    b.Navigation("workouts");
                });
#pragma warning restore 612, 618
        }
    }
}
