using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameRounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfQuestions = table.Column<int>(type: "int", nullable: false),
                    TimeStarted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 27, 16, 17, 34, 531, DateTimeKind.Local).AddTicks(5373)),
                    TimeEnded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRounds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStarted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 27, 16, 17, 34, 543, DateTimeKind.Local).AddTicks(3137)),
                    TimeEnded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnsweredCorrectly = table.Column<bool>(type: "bit", nullable: false),
                    GameRoundId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionStatistics_GameRounds_GameRoundId",
                        column: x => x.GameRoundId,
                        principalTable: "GameRounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionStatistics_GameRoundId",
                table: "QuestionStatistics",
                column: "GameRoundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionStatistics");

            migrationBuilder.DropTable(
                name: "GameRounds");
        }
    }
}
