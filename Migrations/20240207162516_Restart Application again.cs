using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VOTING_APP2.Migrations
{
    /// <inheritdoc />
    public partial class RestartApplicationagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contestants_Sessions_VoteSessionId",
                table: "Contestants");

            migrationBuilder.DropForeignKey(
                name: "FK_Voters_Sessions_VoteSessionId",
                table: "Voters");

            migrationBuilder.AlterColumn<string>(
                name: "VoteSessionId",
                table: "Voters",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VoteSessionId",
                table: "Contestants",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contestants_Sessions_VoteSessionId",
                table: "Contestants",
                column: "VoteSessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_Sessions_VoteSessionId",
                table: "Voters",
                column: "VoteSessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contestants_Sessions_VoteSessionId",
                table: "Contestants");

            migrationBuilder.DropForeignKey(
                name: "FK_Voters_Sessions_VoteSessionId",
                table: "Voters");

            migrationBuilder.AlterColumn<string>(
                name: "VoteSessionId",
                table: "Voters",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "VoteSessionId",
                table: "Contestants",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddForeignKey(
                name: "FK_Contestants_Sessions_VoteSessionId",
                table: "Contestants",
                column: "VoteSessionId",
                principalTable: "Sessions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_Sessions_VoteSessionId",
                table: "Voters",
                column: "VoteSessionId",
                principalTable: "Sessions",
                principalColumn: "Id");
        }
    }
}
