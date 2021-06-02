using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class OliverViability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStarted",
                table: "QuestionStatistics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 2, 14, 12, 9, 803, DateTimeKind.Local).AddTicks(723),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 2, 11, 14, 23, 22, DateTimeKind.Local).AddTicks(9551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStarted",
                table: "GameRounds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 2, 14, 12, 9, 798, DateTimeKind.Local).AddTicks(5891),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 2, 11, 14, 23, 15, DateTimeKind.Local).AddTicks(3037));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStarted",
                table: "QuestionStatistics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 2, 11, 14, 23, 22, DateTimeKind.Local).AddTicks(9551),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 2, 14, 12, 9, 803, DateTimeKind.Local).AddTicks(723));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStarted",
                table: "GameRounds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 2, 11, 14, 23, 15, DateTimeKind.Local).AddTicks(3037),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 2, 14, 12, 9, 798, DateTimeKind.Local).AddTicks(5891));
        }
    }
}
