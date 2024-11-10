using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManager.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreate : Migration
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
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: true),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Tarefas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoAlteracoes",
                columns: table => new
                {
                    HistoricoAlteracaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampoAlterado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Antes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Depois = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAlteracoes", x => x.HistoricoAlteracaoId);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "TarefaId",
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
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Nome" },
                values: new object[,]
                {
                    { new Guid("0f58ef89-c87e-4c09-a9ad-4cbc2f764aec"), "Jimmy Page" },
                    { new Guid("a69c1158-3c7e-4441-a3da-d060c2b5604c"), "Jimmy Hendrix" }
                });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "TarefaId", "DataVencimento", "Descricao", "Prioridade", "ProjetoId", "Status", "Titulo", "UsuarioId" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2024, 11, 25, 11, 43, 18, 654, DateTimeKind.Local).AddTicks(5838), "Essa é uma tarefa para marcar uma reunião com o time", 3, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 2, "Marcar reunião de retrospectiva com os membros do time", new Guid("0f58ef89-c87e-4c09-a9ad-4cbc2f764aec") },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new DateTime(2024, 11, 15, 11, 43, 18, 654, DateTimeKind.Local).AddTicks(5815), "Essa é uma tarefa para realizar o cadastro de usuários no sistema", 2, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 1, "Cadastrar Usuários no Sistema", new Guid("a69c1158-3c7e-4441-a3da-d060c2b5604c") },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new DateTime(2024, 11, 20, 11, 43, 18, 654, DateTimeKind.Local).AddTicks(5835), "Essa é uma tarefa para criar uma nova sprint para o projeto", 1, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 3, "Criar uma nova Sprint para o Projeto", new Guid("a69c1158-3c7e-4441-a3da-d060c2b5604c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_TarefaId",
                table: "HistoricoAlteracoes",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsuarioId",
                table: "Tarefas",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoAlteracoes");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
