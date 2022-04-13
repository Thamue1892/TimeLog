using Microsoft.EntityFrameworkCore.Migrations;

namespace Dataframework.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInProject",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInProject", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UserInProject_Project_ProjectId1",
                        column: x => x.ProjectId1,
                        principalSchema: "dbo",
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInProject_User_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInProject_ProjectId",
                schema: "dbo",
                table: "UserInProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInProject_ProjectId1",
                schema: "dbo",
                table: "UserInProject",
                column: "ProjectId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInProject",
                schema: "dbo");
        }
    }
}
