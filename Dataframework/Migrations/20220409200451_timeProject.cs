using Microsoft.EntityFrameworkCore.Migrations;

namespace Dataframework.Migrations
{
    public partial class timeProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeInProject",
                schema: "dbo",
                columns: table => new
                {
                    TimeTrackerId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeInProject", x => new { x.TimeTrackerId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_TimeInProject_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "dbo",
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeInProject_TimeTracker_TimeTrackerId",
                        column: x => x.TimeTrackerId,
                        principalSchema: "dbo",
                        principalTable: "TimeTracker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeInProject_ProjectId",
                schema: "dbo",
                table: "TimeInProject",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeInProject",
                schema: "dbo");
        }
    }
}
