using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionEleves.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etablissements",
                columns: table => new
                {
                    EtablissementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtablissementName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etablissements", x => x.EtablissementId);
                });

            migrationBuilder.CreateTable(
                name: "Etudients",
                columns: table => new
                {
                    EtudientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtudientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EtudientLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EtudientBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EtablissementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudients", x => x.EtudientID);
                    table.ForeignKey(
                        name: "FK_Etudients_Etablissements_EtablissementId",
                        column: x => x.EtablissementId,
                        principalTable: "Etablissements",
                        principalColumn: "EtablissementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etudients_EtablissementId",
                table: "Etudients",
                column: "EtablissementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etudients");

            migrationBuilder.DropTable(
                name: "Etablissements");
        }
    }
}
