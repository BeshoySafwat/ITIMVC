using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Project.Models.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Manager = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Degree = table.Column<float>(type: "real", nullable: false),
                    MinDegree = table.Column<float>(type: "real", nullable: false),
                    Hours = table.Column<float>(type: "real", nullable: false),
                    dept_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Grade = table.Column<float>(type: "real", nullable: false),
                    dept_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainees_Departments_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Salaey = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Image = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    dept_id = table.Column<int>(type: "int", nullable: false),
                    Crs_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Courses_Crs_id",
                        column: x => x.Crs_id,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseResule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<float>(type: "real", nullable: false),
                    CRS_Id = table.Column<int>(type: "int", nullable: false),
                    Trainee_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseResule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseResule_Courses_CRS_Id",
                        column: x => x.CRS_Id,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseResule_Trainees_Trainee_Id",
                        column: x => x.Trainee_Id,
                        principalTable: "Trainees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseResule_CRS_Id",
                table: "CourseResule",
                column: "CRS_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResule_Trainee_Id",
                table: "CourseResule",
                column: "Trainee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_dept_id",
                table: "Courses",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Crs_id",
                table: "Instructors",
                column: "Crs_id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_dept_id",
                table: "Instructors",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_dept_id",
                table: "Trainees",
                column: "dept_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseResule");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
