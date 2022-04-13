using Microsoft.EntityFrameworkCore.Migrations;

namespace Dataframework.Migrations
{
    public partial class addNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "dbo",
                table: "TimeTracker",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "dbo",
                table: "TimeTracker");
        }
    }
}
