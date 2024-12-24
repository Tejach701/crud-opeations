using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employees.Migrations
{
    /// <inheritdoc />
    public partial class intialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    jobid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jobtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maxsalary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    minsalary = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.jobid);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    regionid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    regionname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regions", x => x.regionid);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    countryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    regionid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.countryid);
                    table.ForeignKey(
                        name: "FK_countries_regions_regionid",
                        column: x => x.regionid,
                        principalTable: "regions",
                        principalColumn: "regionid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    locationid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stateprovience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.locationid);
                    table.ForeignKey(
                        name: "FK_locations_countries_countryid",
                        column: x => x.countryid,
                        principalTable: "countries",
                        principalColumn: "countryid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    departmentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locationid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.departmentid);
                    table.ForeignKey(
                        name: "FK_Departments_locations_locationid",
                        column: x => x.locationid,
                        principalTable: "locations",
                        principalColumn: "locationid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hiredate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    managerid = table.Column<int>(type: "int", nullable: false),
                    departmentid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.empid);
                    table.ForeignKey(
                        name: "FK_employees_Departments_departmentid",
                        column: x => x.departmentid,
                        principalTable: "Departments",
                        principalColumn: "departmentid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_jobs_jobid",
                        column: x => x.jobid,
                        principalTable: "jobs",
                        principalColumn: "jobid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dependents",
                columns: table => new
                {
                    dependentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dependents", x => x.dependentid);
                    table.ForeignKey(
                        name: "FK_dependents_employees_empid",
                        column: x => x.empid,
                        principalTable: "employees",
                        principalColumn: "empid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_countries_regionid",
                table: "countries",
                column: "regionid");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_locationid",
                table: "Departments",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "IX_dependents_empid",
                table: "dependents",
                column: "empid");

            migrationBuilder.CreateIndex(
                name: "IX_employees_departmentid",
                table: "employees",
                column: "departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_employees_jobid",
                table: "employees",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_locations_countryid",
                table: "locations",
                column: "countryid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dependents");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "regions");
        }
    }
}
