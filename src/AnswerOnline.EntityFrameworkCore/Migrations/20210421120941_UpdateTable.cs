using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnswerOnline.EntityFrameworkCore.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubmitItem");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Submit",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Submit");

            migrationBuilder.CreateTable(
                name: "SubmitItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    SubmitId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmitItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmitItem_Submit_SubmitId",
                        column: x => x.SubmitId,
                        principalTable: "Submit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubmitItem_SubmitId",
                table: "SubmitItem",
                column: "SubmitId");
        }
    }
}
