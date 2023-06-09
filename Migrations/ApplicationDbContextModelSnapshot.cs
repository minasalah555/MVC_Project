﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using University.Data;

#nullable disable

namespace University.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("University.Models.Assistant", b =>
                {
                    b.Property<int>("assistant_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("assistant_id"));

                    b.Property<string>("Assistant_Pic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("contact_number")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("department_id")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("assistant_id");

                    b.HasIndex("department_id");

                    b.ToTable("Assistant");
                });

            modelBuilder.Entity("University.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<int>("student_id")
                        .HasColumnType("int");

                    b.Property<int?>("student_id1")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("student_id1");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("University.Models.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItemId"));

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("course_id")
                        .HasColumnType("int");

                    b.Property<string>("course_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("creditHour")
                        .HasColumnType("int");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("University.Models.Course", b =>
                {
                    b.Property<int>("course_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("course_id"));

                    b.Property<string>("Course_Pic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("course_credits")
                        .HasColumnType("int");

                    b.Property<string>("course_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("department_id")
                        .HasColumnType("int");

                    b.Property<int>("semester")
                        .HasColumnType("int");

                    b.HasKey("course_id");

                    b.HasIndex("department_id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("University.Models.Departments", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("department_Pic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("department_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("department");
                });

            modelBuilder.Entity("University.Models.RegisterViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("University.Models.Student", b =>
                {
                    b.Property<int>("student_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("student_id"));

                    b.Property<string>("Student_Pic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("contact_number")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("department_id")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("gpa")
                        .HasColumnType("float");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("student_id");

                    b.HasIndex("department_id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("University.Models.assistant_course", b =>
                {
                    b.Property<int>("course_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("assistantCoursecourse_id")
                        .HasColumnType("int");

                    b.Property<int>("assistant_id")
                        .HasColumnType("int");

                    b.HasKey("course_id");

                    b.HasIndex("assistantCoursecourse_id");

                    b.HasIndex("assistant_id");

                    b.ToTable("assistant_course");
                });

            modelBuilder.Entity("University.Models.assistant_proffessor", b =>
                {
                    b.Property<int>("professor_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("assistantProffessorprofessor_id")
                        .HasColumnType("int");

                    b.Property<int>("assistant_id")
                        .HasColumnType("int");

                    b.HasKey("professor_id");

                    b.HasIndex("assistantProffessorprofessor_id");

                    b.HasIndex("assistant_id");

                    b.ToTable("assistant_proffessor");
                });

            modelBuilder.Entity("University.Models.proffessor", b =>
                {
                    b.Property<int>("doctor_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("doctor_id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("contact_number")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("department_id")
                        .HasColumnType("int");

                    b.Property<string>("doctor_Pic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("doctor_id");

                    b.HasIndex("department_id");

                    b.ToTable("proffessor");
                });

            modelBuilder.Entity("University.Models.proffessor_course", b =>
                {
                    b.Property<int>("professor_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("course_id")
                        .HasColumnType("int");

                    b.Property<int?>("proffessorCoursecourse_id")
                        .HasColumnType("int");

                    b.Property<int?>("proffessorCourseprofessor_id")
                        .HasColumnType("int");

                    b.HasKey("professor_id", "course_id");

                    b.HasIndex("course_id");

                    b.HasIndex("proffessorCourseprofessor_id", "proffessorCoursecourse_id");

                    b.ToTable("proffessor_course");
                });

            modelBuilder.Entity("University.Models.student_assistant", b =>
                {
                    b.Property<int>("student_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("assistant_id")
                        .HasColumnType("int");

                    b.Property<int?>("studentAssistantassistant_id")
                        .HasColumnType("int");

                    b.Property<int?>("studentAssistantstudent_id")
                        .HasColumnType("int");

                    b.HasKey("student_id", "assistant_id");

                    b.HasIndex("assistant_id");

                    b.HasIndex("studentAssistantstudent_id", "studentAssistantassistant_id");

                    b.ToTable("student_assistant");
                });

            modelBuilder.Entity("University.Models.student_course", b =>
                {
                    b.Property<int>("student_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("course_id")
                        .HasColumnType("int");

                    b.Property<string>("grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("studentsCoursecourse_id")
                        .HasColumnType("int");

                    b.Property<int?>("studentsCoursestudent_id")
                        .HasColumnType("int");

                    b.HasKey("student_id", "course_id");

                    b.HasIndex("course_id");

                    b.HasIndex("studentsCoursestudent_id", "studentsCoursecourse_id");

                    b.ToTable("student_course");
                });

            modelBuilder.Entity("University.Models.student_proffessor", b =>
                {
                    b.Property<int>("student_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("professor_id")
                        .HasColumnType("int");

                    b.Property<int?>("studentProffessorprofessor_id")
                        .HasColumnType("int");

                    b.Property<int?>("studentProffessorstudent_id")
                        .HasColumnType("int");

                    b.HasKey("student_id", "professor_id");

                    b.HasIndex("professor_id");

                    b.HasIndex("studentProffessorstudent_id", "studentProffessorprofessor_id");

                    b.ToTable("student_proffessor");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("University.Models.Assistant", b =>
                {
                    b.HasOne("University.Models.Departments", "Department")
                        .WithMany("assistants")
                        .HasForeignKey("department_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("University.Models.Cart", b =>
                {
                    b.HasOne("University.Models.Student", "Student")
                        .WithMany("Carts")
                        .HasForeignKey("student_id1");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("University.Models.CartItem", b =>
                {
                    b.HasOne("University.Models.Cart", null)
                        .WithMany("Items")
                        .HasForeignKey("CartId");
                });

            modelBuilder.Entity("University.Models.Course", b =>
                {
                    b.HasOne("University.Models.Departments", "Department")
                        .WithMany("courses")
                        .HasForeignKey("department_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("University.Models.Student", b =>
                {
                    b.HasOne("University.Models.Departments", "Department")
                        .WithMany("students")
                        .HasForeignKey("department_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("University.Models.assistant_course", b =>
                {
                    b.HasOne("University.Models.assistant_course", "assistantCourse")
                        .WithMany()
                        .HasForeignKey("assistantCoursecourse_id");

                    b.HasOne("University.Models.Assistant", "assistant")
                        .WithMany("assistants_courses")
                        .HasForeignKey("assistant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Models.Course", "course")
                        .WithMany("assistants_courses")
                        .HasForeignKey("course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("assistant");

                    b.Navigation("assistantCourse");

                    b.Navigation("course");
                });

            modelBuilder.Entity("University.Models.assistant_proffessor", b =>
                {
                    b.HasOne("University.Models.assistant_proffessor", "assistantProffessor")
                        .WithMany()
                        .HasForeignKey("assistantProffessorprofessor_id");

                    b.HasOne("University.Models.Assistant", "assistant")
                        .WithMany("assistants_proffessors")
                        .HasForeignKey("assistant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Models.proffessor", "Proffessor")
                        .WithMany("assistant_proffessors")
                        .HasForeignKey("professor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proffessor");

                    b.Navigation("assistant");

                    b.Navigation("assistantProffessor");
                });

            modelBuilder.Entity("University.Models.proffessor", b =>
                {
                    b.HasOne("University.Models.Departments", "Department")
                        .WithMany("proffessors")
                        .HasForeignKey("department_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("University.Models.proffessor_course", b =>
                {
                    b.HasOne("University.Models.Course", "course")
                        .WithMany("proffessors_courses")
                        .HasForeignKey("course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Models.proffessor", "Proffessor")
                        .WithMany("proffessor_courses")
                        .HasForeignKey("professor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Models.proffessor_course", "proffessorCourse")
                        .WithMany()
                        .HasForeignKey("proffessorCourseprofessor_id", "proffessorCoursecourse_id");

                    b.Navigation("Proffessor");

                    b.Navigation("course");

                    b.Navigation("proffessorCourse");
                });

            modelBuilder.Entity("University.Models.student_assistant", b =>
                {
                    b.HasOne("University.Models.Assistant", "assistant")
                        .WithMany("students_assistants")
                        .HasForeignKey("assistant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Models.Student", "Student")
                        .WithMany("students_assistants")
                        .HasForeignKey("student_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Models.student_assistant", "studentAssistant")
                        .WithMany()
                        .HasForeignKey("studentAssistantstudent_id", "studentAssistantassistant_id");

                    b.Navigation("Student");

                    b.Navigation("assistant");

                    b.Navigation("studentAssistant");
                });

            modelBuilder.Entity("University.Models.student_course", b =>
                {
                    b.HasOne("University.Models.Course", "course")
                        .WithMany("students_courses")
                        .HasForeignKey("course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Models.Student", "Student")
                        .WithMany("student_courses")
                        .HasForeignKey("student_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Models.student_course", "studentsCourse")
                        .WithMany()
                        .HasForeignKey("studentsCoursestudent_id", "studentsCoursecourse_id");

                    b.Navigation("Student");

                    b.Navigation("course");

                    b.Navigation("studentsCourse");
                });

            modelBuilder.Entity("University.Models.student_proffessor", b =>
                {
                    b.HasOne("University.Models.proffessor", "professor")
                        .WithMany("student_proffessors")
                        .HasForeignKey("professor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Models.Student", "student")
                        .WithMany("students_proffessors")
                        .HasForeignKey("student_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Models.student_proffessor", "studentProffessor")
                        .WithMany()
                        .HasForeignKey("studentProffessorstudent_id", "studentProffessorprofessor_id");

                    b.Navigation("professor");

                    b.Navigation("student");

                    b.Navigation("studentProffessor");
                });

            modelBuilder.Entity("University.Models.Assistant", b =>
                {
                    b.Navigation("assistants_courses");

                    b.Navigation("assistants_proffessors");

                    b.Navigation("students_assistants");
                });

            modelBuilder.Entity("University.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("University.Models.Course", b =>
                {
                    b.Navigation("assistants_courses");

                    b.Navigation("proffessors_courses");

                    b.Navigation("students_courses");
                });

            modelBuilder.Entity("University.Models.Departments", b =>
                {
                    b.Navigation("assistants");

                    b.Navigation("courses");

                    b.Navigation("proffessors");

                    b.Navigation("students");
                });

            modelBuilder.Entity("University.Models.Student", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("student_courses");

                    b.Navigation("students_assistants");

                    b.Navigation("students_proffessors");
                });

            modelBuilder.Entity("University.Models.proffessor", b =>
                {
                    b.Navigation("assistant_proffessors");

                    b.Navigation("proffessor_courses");

                    b.Navigation("student_proffessors");
                });
#pragma warning restore 612, 618
        }
    }
}
