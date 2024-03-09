using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOAMP_SITE.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favoris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdAvis = table.Column<string>(type: "TEXT", nullable: false),
                    Objet = table.Column<string>(type: "TEXT", nullable: false),
                    DateFinDiffusion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateAjout = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoris", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoris");
        }
    }
}
