using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indimin.EastView.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUIDADANO",
                columns: table => new
                {
                    CuidadanoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUIDADANO", x => x.CuidadanoId);
                });

            migrationBuilder.CreateTable(
                name: "TAREA",
                columns: table => new
                {
                    TareaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CuidadanoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAREA", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_TAREA_CUIDADANO_CuidadanoId",
                        column: x => x.CuidadanoId,
                        principalTable: "CUIDADANO",
                        principalColumn: "CuidadanoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAREA_CuidadanoId",
                table: "TAREA",
                column: "CuidadanoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAREA");

            migrationBuilder.DropTable(
                name: "CUIDADANO");
        }
    }
}
