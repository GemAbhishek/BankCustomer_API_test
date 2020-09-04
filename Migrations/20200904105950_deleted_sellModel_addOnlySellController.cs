using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRepositoryDemo.Migrations
{
    public partial class deleted_sellModel_addOnlySellController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sells");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "SellRecords");

            migrationBuilder.AddColumn<double>(
                name: "SellQty",
                table: "SellRecords",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellQty",
                table: "SellRecords");

            migrationBuilder.AddColumn<double>(
                name: "Qty",
                table: "SellRecords",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Sells",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QtySell = table.Column<int>(type: "int", nullable: false),
                    SellRecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sells", x => x.id);
                });
        }
    }
}
