﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student_CourseManagement.Persistance.DB;

#nullable disable

namespace Student_CourseManagement.Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241026144519_initialMig")]
    partial class initialMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Student_CourseManagement.Domain.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Student_CourseManagement.Domain.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAssigned")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Student_CourseManagement.Domain.Models.StudentCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("Student_CourseManagement.Domain.Models.Course", b =>
                {
                    b.HasOne("Student_CourseManagement.Domain.Models.StudentCourse", null)
                        .WithMany("course")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("Student_CourseManagement.Domain.Models.Student", b =>
                {
                    b.HasOne("Student_CourseManagement.Domain.Models.StudentCourse", null)
                        .WithMany("student")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("Student_CourseManagement.Domain.Models.StudentCourse", b =>
                {
                    b.Navigation("course");

                    b.Navigation("student");
                });
#pragma warning restore 612, 618
        }
    }
}
