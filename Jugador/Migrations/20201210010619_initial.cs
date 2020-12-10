using Microsoft.EntityFrameworkCore.Migrations;

namespace Jugador.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    JugadorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    Puntuacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.JugadorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugadores");
        }
    }
}
