using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddHistoricoAlteracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoAlteracao",
                columns: table => new
                {
                    HistoricoAlteracaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampoAlterado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Antes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Depois = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAlteracao", x => x.HistoricoAlteracaoId);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracao_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "TarefaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 25, 9, 49, 17, 845, DateTimeKind.Local).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 15, 9, 49, 17, 845, DateTimeKind.Local).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 20, 9, 49, 17, 845, DateTimeKind.Local).AddTicks(8384));

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracao_TarefaId",
                table: "HistoricoAlteracao",
                column: "TarefaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoAlteracao");

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 25, 8, 27, 15, 826, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 15, 8, 27, 15, 826, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 20, 8, 27, 15, 826, DateTimeKind.Local).AddTicks(9328));
        }
    }
}
