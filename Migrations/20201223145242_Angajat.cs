using Microsoft.EntityFrameworkCore.Migrations;

namespace Bodea_Denis.Migrations
{
    public partial class Angajat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AngajatID",
                table: "Masina",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Angajat",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeAngajat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dotare",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DotareNume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dotare", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MasinaDotare",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasinaID = table.Column<int>(nullable: false),
                    DotareID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasinaDotare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MasinaDotare_Dotare_DotareID",
                        column: x => x.DotareID,
                        principalTable: "Dotare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasinaDotare_Masina_MasinaID",
                        column: x => x.MasinaID,
                        principalTable: "Masina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masina_AngajatID",
                table: "Masina",
                column: "AngajatID");

            migrationBuilder.CreateIndex(
                name: "IX_MasinaDotare_DotareID",
                table: "MasinaDotare",
                column: "DotareID");

            migrationBuilder.CreateIndex(
                name: "IX_MasinaDotare_MasinaID",
                table: "MasinaDotare",
                column: "MasinaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masina_Angajat_AngajatID",
                table: "Masina",
                column: "AngajatID",
                principalTable: "Angajat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masina_Angajat_AngajatID",
                table: "Masina");

            migrationBuilder.DropTable(
                name: "Angajat");

            migrationBuilder.DropTable(
                name: "MasinaDotare");

            migrationBuilder.DropTable(
                name: "Dotare");

            migrationBuilder.DropIndex(
                name: "IX_Masina_AngajatID",
                table: "Masina");

            migrationBuilder.DropColumn(
                name: "AngajatID",
                table: "Masina");
        }
    }
}
