using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColunaPrioriedade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prioridade",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "DataVencimento", "Prioridade" },
                values: new object[] { new DateTime(2024, 11, 25, 7, 54, 16, 543, DateTimeKind.Local).AddTicks(1946), 0 });

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "DataVencimento", "Prioridade" },
                values: new object[] { new DateTime(2024, 11, 15, 7, 54, 16, 543, DateTimeKind.Local).AddTicks(1928), 0 });

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "DataVencimento", "Prioridade" },
                values: new object[] { new DateTime(2024, 11, 20, 7, 54, 16, 543, DateTimeKind.Local).AddTicks(1944), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prioridade",
                table: "Tarefas");

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 24, 13, 34, 24, 340, DateTimeKind.Local).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 14, 13, 34, 24, 340, DateTimeKind.Local).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 19, 13, 34, 24, 340, DateTimeKind.Local).AddTicks(3757));
        }
    }
}
