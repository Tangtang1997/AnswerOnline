using Microsoft.EntityFrameworkCore.Migrations;

namespace AnswerOnline.EntityFrameworkCore.Migrations
{
    public partial class UpdateSubmit_TimeOfSubmit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TimeOfSubmit",
                table: "Submit",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TimeOfSubmit",
                table: "Submit",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
