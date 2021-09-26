using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodChildren.Migrations
{
    public partial class @in : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Vladelec",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VladelecId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Zayavki",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VladelecId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Zayavki",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "Vladelec",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
