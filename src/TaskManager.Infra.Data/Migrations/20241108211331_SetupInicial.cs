using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManager.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetupInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.ProjetoId);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.TarefaId);
                    table.ForeignKey(
                        name: "FK_Tarefas_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projetos",
                columns: new[] { "ProjetoId", "Nome" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Projeto X" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Projeto Z" }
                });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "TarefaId", "DataVencimento", "Descricao", "ProjetoId", "Titulo" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2024, 11, 23, 18, 13, 31, 280, DateTimeKind.Local).AddTicks(8506), "Essa é uma tarefa para marcar uma reunião com o time", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Marcar reunião de retrospectiva com os membros do time" },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new DateTime(2024, 11, 13, 18, 13, 31, 280, DateTimeKind.Local).AddTicks(8485), "Essa é uma tarefa para realizar o cadastro de usuários no sistema", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Cadastrar Usuários no Sistema" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new DateTime(2024, 11, 18, 18, 13, 31, 280, DateTimeKind.Local).AddTicks(8503), "Essa é uma tarefa para criar uma nova sprint para o projeto", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Criar uma nova Sprint para o Projeto" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}
