using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    EmprestimoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.EmprestimoId);
                });

            migrationBuilder.CreateTable(
                name: "instituicoesEnsino",
                columns: table => new
                {
                    InstituicaoEnsinoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    CPNJ = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instituicoesEnsino", x => x.InstituicaoEnsinoId);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    DataReserva = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Endereço = table.Column<int>(nullable: false),
                    CPF = table.Column<int>(nullable: false),
                    Telefone = table.Column<int>(nullable: false),
                    EMail = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    InstituicaoEnsinoId = table.Column<int>(nullable: true),
                    AutorId = table.Column<int>(nullable: true),
                    LivroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_instituicoesEnsino_InstituicaoEnsinoId",
                        column: x => x.InstituicaoEnsinoId,
                        principalTable: "instituicoesEnsino",
                        principalColumn: "InstituicaoEnsinoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    LivroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: true),
                    Genero = table.Column<string>(nullable: true),
                    Sinopse = table.Column<string>(nullable: true),
                    ImagemURL = table.Column<string>(nullable: true),
                    AutorUsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.LivroId);
                    table.ForeignKey(
                        name: "FK_Livros_Usuarios_AutorUsuarioId",
                        column: x => x.AutorUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_AutorUsuarioId",
                table: "Livros",
                column: "AutorUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_InstituicaoEnsinoId",
                table: "Usuarios",
                column: "InstituicaoEnsinoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimos");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "instituicoesEnsino");
        }
    }
}
