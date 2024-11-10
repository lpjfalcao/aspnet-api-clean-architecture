using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNullColunaPrioreidadeTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Prioridade",
                table: "Tarefas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "DataVencimento", "Prioridade", "Status" },
                values: new object[] { new DateTime(2024, 11, 25, 8, 27, 15, 826, DateTimeKind.Local).AddTicks(9331), 3, 2 });

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "DataVencimento", "Prioridade", "Status" },
                values: new object[] { new DateTime(2024, 11, 15, 8, 27, 15, 826, DateTimeKind.Local).AddTicks(9307), 2, 1 });

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "DataVencimento", "Prioridade", "Status" },
                values: new object[] { new DateTime(2024, 11, 20, 8, 27, 15, 826, DateTimeKind.Local).AddTicks(9328), 1, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Prioridade",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "DataVencimento", "Prioridade", "Status" },
                values: new object[] { new DateTime(2024, 11, 25, 7, 54, 16, 543, DateTimeKind.Local).AddTicks(1946), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "DataVencimento", "Prioridade", "Status" },
                values: new object[] { new DateTime(2024, 11, 15, 7, 54, 16, 543, DateTimeKind.Local).AddTicks(1928), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "DataVencimento", "Prioridade", "Status" },
                values: new object[] { new DateTime(2024, 11, 20, 7, 54, 16, 543, DateTimeKind.Local).AddTicks(1944), 0, 0 });
        }
    }
}
