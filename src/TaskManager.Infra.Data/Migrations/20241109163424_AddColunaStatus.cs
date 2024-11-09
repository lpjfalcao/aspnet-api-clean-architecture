using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColunaStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "DataVencimento", "Status" },
                values: new object[] { new DateTime(2024, 11, 24, 13, 34, 24, 340, DateTimeKind.Local).AddTicks(3760), 0 });

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "DataVencimento", "Status" },
                values: new object[] { new DateTime(2024, 11, 14, 13, 34, 24, 340, DateTimeKind.Local).AddTicks(3739), 0 });

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "DataVencimento", "Status" },
                values: new object[] { new DateTime(2024, 11, 19, 13, 34, 24, 340, DateTimeKind.Local).AddTicks(3757), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tarefas");

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 23, 18, 13, 31, 280, DateTimeKind.Local).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 13, 18, 13, 31, 280, DateTimeKind.Local).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "Tarefas",
                keyColumn: "TarefaId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                column: "DataVencimento",
                value: new DateTime(2024, 11, 18, 18, 13, 31, 280, DateTimeKind.Local).AddTicks(8503));
        }
    }
}
