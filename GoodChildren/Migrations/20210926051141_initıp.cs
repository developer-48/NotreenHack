using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodChildren.Migrations
{
    public partial class initıp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Vladelec",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Vladelec",
                table: "Events");
        }
    }
}
