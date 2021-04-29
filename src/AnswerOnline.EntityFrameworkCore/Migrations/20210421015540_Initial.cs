using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnswerOnline.EntityFrameworkCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commissioner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissioner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    HighestScore = table.Column<int>(type: "int", nullable: false),
                    TimeOfHighestScore = table.Column<double>(type: "float", nullable: false),
                    AnsweredNumber = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Submit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false),
                    SubmitterId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false),
                    TimeOfSubmit = table.Column<double>(type: "float", nullable: false),
                    SendWord = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Stem = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Bzojlydsy = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    QuestionType = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CommissionerId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Commissioner_CommissionerId",
                        column: x => x.CommissionerId,
                        principalTable: "Commissioner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubmitItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    SubmitId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "QuestionChoiceOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false),
                    Option = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OptionType = table.Column<int>(type: "int", nullable: false),
                    IsAnswer = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionChoiceOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionChoiceOption_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_CommissionerId",
                table: "Question",
                column: "CommissionerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionChoiceOption_QuestionId",
                table: "QuestionChoiceOption",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmitItem_SubmitId",
                table: "SubmitItem",
                column: "SubmitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "QuestionChoiceOption");

            migrationBuilder.DropTable(
                name: "SubmitItem");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Submit");

            migrationBuilder.DropTable(
                name: "Commissioner");
        }
    }
}
