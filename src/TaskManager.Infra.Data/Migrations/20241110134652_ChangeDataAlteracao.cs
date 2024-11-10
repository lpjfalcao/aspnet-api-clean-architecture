using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDataAlteracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "HistoricoAlteracao",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 25, 10, 46, 51, 827, DateTimeKind.Local).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 15, 10, 46, 51, 827, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 20, 10, 46, 51, 827, DateTimeKind.Local).AddTicks(897));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataAlteracao",
                table: "HistoricoAlteracao",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
        }
    }
}
