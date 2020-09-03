using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRepositoryDemo.Migrations
{
    public partial class InitialModelCorrecting_Sell_Record_adding_BookName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SellRecords",
                table: "SellRecords");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "SellRecords");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SellRecords",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "SellRecords",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellRecords",
                table: "SellRecords",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SellRecords",
                table: "SellRecords");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SellRecords");

            migrationBuilder.DropColumn(
                name: "BookName",
                table: "SellRecords");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "SellRecords",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellRecords",
                table: "SellRecords",
                column: "BookId");
        }
    }
}
