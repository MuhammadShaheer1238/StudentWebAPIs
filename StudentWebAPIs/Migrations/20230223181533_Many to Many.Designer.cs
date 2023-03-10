// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentWebAPIs.Data;

#nullable disable

namespace StudentWebAPIs.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20230223181533_Many to Many")]
    partial class ManytoMany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentWebAPIs.Model.Domain.Courses", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InstructorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("StudentWebAPIs.Model.Domain.Instructors", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("InstructorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNum")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("instructors");
                });

            modelBuilder.Entity("StudentWebAPIs.Model.Domain.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PhoneNum")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("StudentWebAPIs.Model.Domain.StudentCourses", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("studentCourses");
                });

            modelBuilder.Entity("StudentWebAPIs.Model.Domain.Courses", b =>
                {
                    b.HasOne("StudentWebAPIs.Model.Domain.Instructors", "Instructors")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("StudentWebAPIs.Model.Domain.StudentCourses", b =>
                {
                    b.HasOne("StudentWebAPIs.Model.Domain.Courses", "Course")
                        .WithMany("studentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentWebAPIs.Model.Domain.Student", "Student")
                        .WithMany("studentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentWebAPIs.Model.Domain.Courses", b =>
                {
                    b.Navigation("studentCourses");
                });

            modelBuilder.Entity("StudentWebAPIs.Model.Domain.Instructors", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("StudentWebAPIs.Model.Domain.Student", b =>
                {
                    b.Navigation("studentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
