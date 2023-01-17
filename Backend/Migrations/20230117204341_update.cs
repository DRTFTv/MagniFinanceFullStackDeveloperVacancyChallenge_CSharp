using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses_tb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "grades_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeOne = table.Column<double>(type: "float", nullable: false),
                    GradeTwo = table.Column<double>(type: "float", nullable: false),
                    GradeThree = table.Column<double>(type: "float", nullable: false),
                    GradeFour = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grades_tb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "students_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students_tb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teachers_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers_tb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subjects_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CoursesNavigationId = table.Column<int>(type: "int", nullable: false),
                    TeachersNavigationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects_tb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subjects_tb_courses_tb_CoursesNavigationId",
                        column: x => x.CoursesNavigationId,
                        principalTable: "courses_tb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subjects_tb_teachers_tb_TeachersNavigationId",
                        column: x => x.TeachersNavigationId,
                        principalTable: "teachers_tb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students_subjects_tb",
                columns: table => new
                {
                    RegistrationNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    StudentsNavigationId = table.Column<int>(type: "int", nullable: false),
                    SubjectsNavigationId = table.Column<int>(type: "int", nullable: false),
                    GradesNavigationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students_subjects_tb", x => x.RegistrationNumber);
                    table.ForeignKey(
                        name: "FK_students_subjects_tb_grades_tb_GradesNavigationId",
                        column: x => x.GradesNavigationId,
                        principalTable: "grades_tb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_students_subjects_tb_students_tb_StudentsNavigationId",
                        column: x => x.StudentsNavigationId,
                        principalTable: "students_tb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_students_subjects_tb_subjects_tb_SubjectsNavigationId",
                        column: x => x.SubjectsNavigationId,
                        principalTable: "subjects_tb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_students_subjects_tb_GradesNavigationId",
                table: "students_subjects_tb",
                column: "GradesNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_students_subjects_tb_StudentsNavigationId",
                table: "students_subjects_tb",
                column: "StudentsNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_students_subjects_tb_SubjectsNavigationId",
                table: "students_subjects_tb",
                column: "SubjectsNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_tb_CoursesNavigationId",
                table: "subjects_tb",
                column: "CoursesNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_tb_TeachersNavigationId",
                table: "subjects_tb",
                column: "TeachersNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students_subjects_tb");

            migrationBuilder.DropTable(
                name: "grades_tb");

            migrationBuilder.DropTable(
                name: "students_tb");

            migrationBuilder.DropTable(
                name: "subjects_tb");

            migrationBuilder.DropTable(
                name: "courses_tb");

            migrationBuilder.DropTable(
                name: "teachers_tb");
        }
    }
}
