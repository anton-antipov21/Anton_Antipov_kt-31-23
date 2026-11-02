using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Anton_Antipov_kt_31_23.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "disciplines",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplines", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "specialities",
                columns: table => new
                {
                    speciality_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialities", x => x.speciality_id);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    group_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    group_course = table.Column<int>(type: "integer", nullable: false),
                    speciality_id = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.group_id);
                    table.ForeignKey(
                        name: "FK_groups_specialities_speciality_id",
                        column: x => x.speciality_id,
                        principalTable: "specialities",
                        principalColumn: "speciality_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    student_firstname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    student_lastname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    group_id = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.student_id);
                    table.ForeignKey(
                        name: "FK_students_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "grades",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<int>(type: "integer", nullable: false),
                    student_id = table.Column<int>(type: "integer", nullable: false),
                    discipline_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grades", x => x.grade_id);
                    table.ForeignKey(
                        name: "FK_grades_disciplines_discipline_id",
                        column: x => x.discipline_id,
                        principalTable: "disciplines",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_grades_students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_grades_discipline_id",
                table: "grades",
                column: "discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_grades_student_id",
                table: "grades",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_speciality_id",
                table: "groups",
                column: "speciality_id");

            migrationBuilder.CreateIndex(
                name: "IX_students_group_id",
                table: "students",
                column: "group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grades");

            migrationBuilder.DropTable(
                name: "disciplines");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "specialities");
        }
    }
}
