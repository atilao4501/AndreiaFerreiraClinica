using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreiaFerreira.ClinicaApi.Migrations.ClinicDb
{
    /// <inheritdoc />
    public partial class criacaoAgenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Agendas",
                newName: "DataCadastro");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Pacientes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAgendamento",
                table: "Agendas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "DataAgendamento",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Agendas",
                newName: "DataHora");
        }
    }
}
