﻿using Microsoft.EntityFrameworkCore.Migrations;

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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSpratova = table.Column<int>(type: "int", nullable: false),
                    BrojSoba = table.Column<int>(type: "int", nullable: false),
                    BrojKrevetaPoSobi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolnice", x => x.ID);
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
                    Dijagnoza = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sobe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojKreveta = table.Column<int>(type: "int", nullable: false),
                    BolnicaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sobe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sobe_Bolnice_BolnicaID",
                        column: x => x.BolnicaID,
                        principalTable: "Bolnice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kreveti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pacijentID = table.Column<int>(type: "int", nullable: true),
                    Zauzet = table.Column<bool>(type: "bit", nullable: false),
                    SobaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kreveti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kreveti_Pacijenti_pacijentID",
                        column: x => x.pacijentID,
                        principalTable: "Pacijenti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kreveti_Sobe_SobaID",
                        column: x => x.SobaID,
                        principalTable: "Sobe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kreveti_pacijentID",
                table: "Kreveti",
                column: "pacijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Kreveti_SobaID",
                table: "Kreveti",
                column: "SobaID");

            migrationBuilder.CreateIndex(
                name: "IX_Sobe_BolnicaID",
                table: "Sobe",
                column: "BolnicaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kreveti");

            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "Sobe");

            migrationBuilder.DropTable(
                name: "Bolnice");
        }
    }
}