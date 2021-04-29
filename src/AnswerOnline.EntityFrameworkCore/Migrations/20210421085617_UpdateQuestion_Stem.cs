using Microsoft.EntityFrameworkCore.Migrations;

namespace AnswerOnline.EntityFrameworkCore.Migrations
{
    public partial class UpdateQuestion_Stem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bzojlydsy",
                table: "Question",
                newName: "Stem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stem",
                table: "Question",
                newName: "Bzojlydsy");
        }
    }
}
