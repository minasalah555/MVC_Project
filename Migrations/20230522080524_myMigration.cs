using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    /// <inheritdoc />
    public partial class myMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department_Pic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assistant",
                columns: table => new
                {
                    assistant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Assistant_Pic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistant", x => x.assistant_id);
                    table.ForeignKey(
                        name: "FK_Assistant_department_department_id",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    course_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    semester = table.Column<int>(type: "int", nullable: false),
                    course_credits = table.Column<int>(type: "int", nullable: false),
                    course_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: false),
                    Course_Pic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.course_id);
                    table.ForeignKey(
                        name: "FK_Course_department_department_id",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "proffessor",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    doctor_Pic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proffessor", x => x.doctor_id);
                    table.ForeignKey(
                        name: "FK_proffessor_department_department_id",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gpa = table.Column<double>(type: "float", nullable: false),
                    contact_number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Pic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.student_id);
                    table.ForeignKey(
                        name: "FK_Student_department_department_id",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assistant_course",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false),
                    assistant_id = table.Column<int>(type: "int", nullable: false),
                    assistantCoursecourse_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assistant_course", x => x.course_id);
                    table.ForeignKey(
                        name: "FK_assistant_course_Assistant_assistant_id",
                        column: x => x.assistant_id,
                        principalTable: "Assistant",
                        principalColumn: "assistant_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_assistant_course_Course_course_id",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_assistant_course_assistant_course_assistantCoursecourse_id",
                        column: x => x.assistantCoursecourse_id,
                        principalTable: "assistant_course",
                        principalColumn: "course_id");
                });

            migrationBuilder.CreateTable(
                name: "assistant_proffessor",
                columns: table => new
                {
                    professor_id = table.Column<int>(type: "int", nullable: false),
                    assistant_id = table.Column<int>(type: "int", nullable: false),
                    assistantProffessorprofessor_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assistant_proffessor", x => x.professor_id);
                    table.ForeignKey(
                        name: "FK_assistant_proffessor_Assistant_assistant_id",
                        column: x => x.assistant_id,
                        principalTable: "Assistant",
                        principalColumn: "assistant_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_assistant_proffessor_assistant_proffessor_assistantProffessorprofessor_id",
                        column: x => x.assistantProffessorprofessor_id,
                        principalTable: "assistant_proffessor",
                        principalColumn: "professor_id");
                    table.ForeignKey(
                        name: "FK_assistant_proffessor_proffessor_professor_id",
                        column: x => x.professor_id,
                        principalTable: "proffessor",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "proffessor_course",
                columns: table => new
                {
                    professor_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    proffessorCourseprofessor_id = table.Column<int>(type: "int", nullable: true),
                    proffessorCoursecourse_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proffessor_course", x => new { x.professor_id, x.course_id });
                    table.ForeignKey(
                        name: "FK_proffessor_course_Course_course_id",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_proffessor_course_proffessor_course_proffessorCourseprofessor_id_proffessorCoursecourse_id",
                        columns: x => new { x.proffessorCourseprofessor_id, x.proffessorCoursecourse_id },
                        principalTable: "proffessor_course",
                        principalColumns: new[] { "professor_id", "course_id" });
                    table.ForeignKey(
                        name: "FK_proffessor_course_proffessor_professor_id",
                        column: x => x.professor_id,
                        principalTable: "proffessor",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    student_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_Student_student_id1",
                        column: x => x.student_id1,
                        principalTable: "Student",
                        principalColumn: "student_id");
                });

            migrationBuilder.CreateTable(
                name: "student_assistant",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    assistant_id = table.Column<int>(type: "int", nullable: false),
                    studentAssistantstudent_id = table.Column<int>(type: "int", nullable: true),
                    studentAssistantassistant_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_assistant", x => new { x.student_id, x.assistant_id });
                    table.ForeignKey(
                        name: "FK_student_assistant_Assistant_assistant_id",
                        column: x => x.assistant_id,
                        principalTable: "Assistant",
                        principalColumn: "assistant_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_student_assistant_Student_student_id",
                        column: x => x.student_id,
                        principalTable: "Student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_student_assistant_student_assistant_studentAssistantstudent_id_studentAssistantassistant_id",
                        columns: x => new { x.studentAssistantstudent_id, x.studentAssistantassistant_id },
                        principalTable: "student_assistant",
                        principalColumns: new[] { "student_id", "assistant_id" });
                });

            migrationBuilder.CreateTable(
                name: "student_course",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentsCoursestudent_id = table.Column<int>(type: "int", nullable: true),
                    studentsCoursecourse_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_course", x => new { x.student_id, x.course_id });
                    table.ForeignKey(
                        name: "FK_student_course_Course_course_id",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_student_course_Student_student_id",
                        column: x => x.student_id,
                        principalTable: "Student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_student_course_student_course_studentsCoursestudent_id_studentsCoursecourse_id",
                        columns: x => new { x.studentsCoursestudent_id, x.studentsCoursecourse_id },
                        principalTable: "student_course",
                        principalColumns: new[] { "student_id", "course_id" });
                });

            migrationBuilder.CreateTable(
                name: "student_proffessor",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    professor_id = table.Column<int>(type: "int", nullable: false),
                    studentProffessorstudent_id = table.Column<int>(type: "int", nullable: true),
                    studentProffessorprofessor_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_proffessor", x => new { x.student_id, x.professor_id });
                    table.ForeignKey(
                        name: "FK_student_proffessor_Student_student_id",
                        column: x => x.student_id,
                        principalTable: "Student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_student_proffessor_proffessor_professor_id",
                        column: x => x.professor_id,
                        principalTable: "proffessor",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_student_proffessor_student_proffessor_studentProffessorstudent_id_studentProffessorprofessor_id",
                        columns: x => new { x.studentProffessorstudent_id, x.studentProffessorprofessor_id },
                        principalTable: "student_proffessor",
                        principalColumns: new[] { "student_id", "professor_id" });
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    course_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creditHour = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assistant_department_id",
                table: "Assistant",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_assistant_course_assistant_id",
                table: "assistant_course",
                column: "assistant_id");

            migrationBuilder.CreateIndex(
                name: "IX_assistant_course_assistantCoursecourse_id",
                table: "assistant_course",
                column: "assistantCoursecourse_id");

            migrationBuilder.CreateIndex(
                name: "IX_assistant_proffessor_assistant_id",
                table: "assistant_proffessor",
                column: "assistant_id");

            migrationBuilder.CreateIndex(
                name: "IX_assistant_proffessor_assistantProffessorprofessor_id",
                table: "assistant_proffessor",
                column: "assistantProffessorprofessor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_student_id1",
                table: "Cart",
                column: "student_id1");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_department_id",
                table: "Course",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_proffessor_department_id",
                table: "proffessor",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_proffessor_course_course_id",
                table: "proffessor_course",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_proffessor_course_proffessorCourseprofessor_id_proffessorCoursecourse_id",
                table: "proffessor_course",
                columns: new[] { "proffessorCourseprofessor_id", "proffessorCoursecourse_id" });

            migrationBuilder.CreateIndex(
                name: "IX_Student_department_id",
                table: "Student",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_assistant_assistant_id",
                table: "student_assistant",
                column: "assistant_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_assistant_studentAssistantstudent_id_studentAssistantassistant_id",
                table: "student_assistant",
                columns: new[] { "studentAssistantstudent_id", "studentAssistantassistant_id" });

            migrationBuilder.CreateIndex(
                name: "IX_student_course_course_id",
                table: "student_course",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_course_studentsCoursestudent_id_studentsCoursecourse_id",
                table: "student_course",
                columns: new[] { "studentsCoursestudent_id", "studentsCoursecourse_id" });

            migrationBuilder.CreateIndex(
                name: "IX_student_proffessor_professor_id",
                table: "student_proffessor",
                column: "professor_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_proffessor_studentProffessorstudent_id_studentProffessorprofessor_id",
                table: "student_proffessor",
                columns: new[] { "studentProffessorstudent_id", "studentProffessorprofessor_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "assistant_course");

            migrationBuilder.DropTable(
                name: "assistant_proffessor");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "proffessor_course");

            migrationBuilder.DropTable(
                name: "student_assistant");

            migrationBuilder.DropTable(
                name: "student_course");

            migrationBuilder.DropTable(
                name: "student_proffessor");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Assistant");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "proffessor");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}
