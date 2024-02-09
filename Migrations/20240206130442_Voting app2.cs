using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VOTING_APP2.Migrations
{
    /// <inheritdoc />
    public partial class Votingapp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeHeld",
                table: "Sessions",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sessions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "abcd",
                column: "DateCreated",
                value: new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Local));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sessions");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "TimeHeld",
                table: "Sessions",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "abcd",
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
