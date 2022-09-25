using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioServiceApi.Migrations
{
    public partial class Artista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artista",
                columns: table => new
                {
                    codArt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeArt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artista", x => x.codArt);
                });

            migrationBuilder.CreateTable(
                name: "Gravadora",
                columns: table => new
                {
                    codGrav = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeGrav = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gravadora", x => x.codGrav);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    codAlb = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gravadoracodGrav = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.codAlb);
                    table.ForeignKey(
                        name: "FK_Album_Gravadora_gravadoracodGrav",
                        column: x => x.gravadoracodGrav,
                        principalTable: "Gravadora",
                        principalColumn: "codGrav",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumArtista",
                columns: table => new
                {
                    albumscodAlb = table.Column<int>(type: "int", nullable: false),
                    artistascodArt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumArtista", x => new { x.albumscodAlb, x.artistascodArt });
                    table.ForeignKey(
                        name: "FK_AlbumArtista_Album_albumscodAlb",
                        column: x => x.albumscodAlb,
                        principalTable: "Album",
                        principalColumn: "codAlb",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumArtista_Artista_artistascodArt",
                        column: x => x.artistascodArt,
                        principalTable: "Artista",
                        principalColumn: "codArt",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_gravadoracodGrav",
                table: "Album",
                column: "gravadoracodGrav");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumArtista_artistascodArt",
                table: "AlbumArtista",
                column: "artistascodArt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumArtista");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Artista");

            migrationBuilder.DropTable(
                name: "Gravadora");
        }
    }
}
