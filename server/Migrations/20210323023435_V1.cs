using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bolnice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolnice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Spratovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bolnicaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spratovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Spratovi_Bolnice_bolnicaID",
                        column: x => x.bolnicaID,
                        principalTable: "Bolnice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sobe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spratID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sobe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sobe_Spratovi_spratID",
                        column: x => x.spratID,
                        principalTable: "Spratovi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kreveti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zauzet = table.Column<bool>(type: "bit", nullable: false),
                    sobaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kreveti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kreveti_Sobe_sobaID",
                        column: x => x.sobaID,
                        principalTable: "Sobe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Dijeta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Dijagnoza = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KrevetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pacijenti_Kreveti_KrevetId",
                        column: x => x.KrevetId,
                        principalTable: "Kreveti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kreveti_sobaID",
                table: "Kreveti",
                column: "sobaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pacijenti_KrevetId",
                table: "Pacijenti",
                column: "KrevetId",
                unique: true,
                filter: "[KrevetId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sobe_spratID",
                table: "Sobe",
                column: "spratID");

            migrationBuilder.CreateIndex(
                name: "IX_Spratovi_bolnicaID",
                table: "Spratovi",
                column: "bolnicaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "Kreveti");

            migrationBuilder.DropTable(
                name: "Sobe");

            migrationBuilder.DropTable(
                name: "Spratovi");

            migrationBuilder.DropTable(
                name: "Bolnice");
        }
    }
}
