using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VOTING_APP2.Migrations
{
    /// <inheritdoc />
    public partial class RestartApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoteNumber",
                table: "Voters");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "abcd",
                column: "DateCreated",
                value: new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Local));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VoteNumber",
                table: "Voters",
                type: "longtext",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "abcd",
                column: "DateCreated",
                value: new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
