using Microsoft.EntityFrameworkCore.Migrations;

namespace projekt.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    projectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectName = table.Column<string>(nullable: true),
                    employeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.projectID);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_employeeID",
                        column: x => x.employeeID,
                        principalTable: "Employees",
                        principalColumn: "employeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeReports",
                columns: table => new
                {
                    reportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Week = table.Column<int>(nullable: false),
                    date = table.Column<int>(nullable: false),
                    reportedHours = table.Column<double>(nullable: false),
                    employeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReports", x => x.reportID);
                    table.ForeignKey(
                        name: "FK_TimeReports_Employees_employeeID",
                        column: x => x.employeeID,
                        principalTable: "Employees",
                        principalColumn: "employeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "employeeID", "firstName", "lastName", "phone" },
                values: new object[,]
                {
                    { 1, "Ludwig", "Oleby", "0736004656" },
                    { 2, "Anas", "Qlok", "0701231231" },
                    { 3, "Tobias", "Qlok", "0701231232" },
                    { 4, "Reidar", "Qlok", "0701231233" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "projectID", "employeeID", "projectName" },
                values: new object[,]
                {
                    { 1, 1, "C#" },
                    { 2, 2, "C#" },
                    { 3, 3, "HTML" },
                    { 4, 4, "CSS" }
                });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "reportID", "Week", "date", "employeeID", "reportedHours" },
                values: new object[,]
                {
                    { 1, 1, 20220410, 1, 37.5 },
                    { 2, 1, 20220410, 2, 20.0 },
                    { 3, 2, 20220417, 3, 40.0 },
                    { 4, 2, 20220417, 4, 30.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_employeeID",
                table: "Projects",
                column: "employeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_employeeID",
                table: "TimeReports",
                column: "employeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TimeReports");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
