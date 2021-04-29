using Microsoft.EntityFrameworkCore.Migrations;

namespace AnswerOnline.EntityFrameworkCore.Migrations
{
    public partial class UpdateTable_Participent_AddField_Department : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Participant",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Participant");
        }
    }
}
