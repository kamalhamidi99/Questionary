using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionary.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Group = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionChoiceModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Choice = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsAnswer = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionChoiceModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionChoiceModels_QuestionModels_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuestionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStarted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateEnded = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestionGroup = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizModels_UserModels_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizAnswerModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAnswerd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    QuestionChoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAnswerModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizAnswerModels_QuestionChoiceModels_QuestionChoiceId",
                        column: x => x.QuestionChoiceId,
                        principalTable: "QuestionChoiceModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizAnswerModels_QuizModels_QuizId",
                        column: x => x.QuizId,
                        principalTable: "QuizModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "QuestionModels",
                columns: new[] { "Id", "Group", "Question", "Type" },
                values: new object[] { 1, 0, "By convention, what name is used for the first key in a JSON schema?", 0 });

            migrationBuilder.InsertData(
                table: "QuestionModels",
                columns: new[] { "Id", "Group", "Question", "Type" },
                values: new object[] { 2, 0, "Which JavaScript method converts a JavaScript value to Json?", 0 });

            migrationBuilder.InsertData(
                table: "QuestionModels",
                columns: new[] { "Id", "Group", "Question", "Type" },
                values: new object[] { 3, 0, "Which data type is part of JSON standard?", 1 });

            migrationBuilder.InsertData(
                table: "QuestionChoiceModels",
                columns: new[] { "Id", "Choice", "IsAnswer", "QuestionId" },
                values: new object[,]
                {
                    { 1, "schema", false, 1 },
                    { 2, "$schema", true, 1 },
                    { 3, "JsonSchema", false, 1 },
                    { 4, "JSONschema", false, 1 },
                    { 5, "JSON.parse()", false, 2 },
                    { 6, "JSON.stringify()", true, 2 },
                    { 7, "JSON.toString()", false, 2 },
                    { 8, "JSON.objectify()", false, 2 },
                    { 9, "string", true, 3 },
                    { 10, "number", true, 3 },
                    { 11, "date", false, 3 },
                    { 12, "array", true, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionChoiceModels_QuestionId",
                table: "QuestionChoiceModels",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswerModels_QuestionChoiceId",
                table: "QuizAnswerModels",
                column: "QuestionChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswerModels_QuizId",
                table: "QuizAnswerModels",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizModels_UserId",
                table: "QuizModels",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizAnswerModels");

            migrationBuilder.DropTable(
                name: "QuestionChoiceModels");

            migrationBuilder.DropTable(
                name: "QuizModels");

            migrationBuilder.DropTable(
                name: "QuestionModels");

            migrationBuilder.DropTable(
                name: "UserModels");
        }
    }
}
