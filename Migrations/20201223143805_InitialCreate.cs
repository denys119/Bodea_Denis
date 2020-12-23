using Microsoft.EntityFrameworkCore.Migrations;

namespace Bodea_Denis.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Masina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Culoare = table.Column<string>(nullable: true),
                    An = table.Column<string>(nullable: true),
                    Tara = table.Column<string>(nullable: true),
                    Motor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masina", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Masina");
        }
    }
}
