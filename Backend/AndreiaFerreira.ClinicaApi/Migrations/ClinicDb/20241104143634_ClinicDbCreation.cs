using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AndreiaFerreira.ClinicaApi.Migrations.ClinicDb
{
    /// <inheritdoc />
    public partial class ClinicDbCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anamneses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Diabetes = table.Column<bool>(type: "boolean", nullable: false),
                    Fumante = table.Column<bool>(type: "boolean", nullable: false),
                    Esta_menstruada = table.Column<bool>(type: "boolean", nullable: false),
                    Esta_gravida = table.Column<bool>(type: "boolean", nullable: false),
                    Varizes_ou_Lesoes = table.Column<bool>(type: "boolean", nullable: false),
                    Cuidados_diarios_com_a_pele = table.Column<bool>(type: "boolean", nullable: false),
                    Ingere_agua = table.Column<bool>(type: "boolean", nullable: false),
                    Alimentacao_balanceada = table.Column<bool>(type: "boolean", nullable: false),
                    Ingere_bebida_alcoolica = table.Column<bool>(type: "boolean", nullable: false),
                    Pratica_atividade_fisica = table.Column<bool>(type: "boolean", nullable: false),
                    Antecedentes_oncologicos = table.Column<bool>(type: "boolean", nullable: false),
                    Problemas_ortopedicos = table.Column<bool>(type: "boolean", nullable: false),
                    Medicamentos_de_uso_diario = table.Column<bool>(type: "boolean", nullable: false),
                    Disturbio_hormonal = table.Column<bool>(type: "boolean", nullable: false),
                    Funcionamento_intestinal_regular = table.Column<bool>(type: "boolean", nullable: false),
                    Disturbio_circulatorio = table.Column<bool>(type: "boolean", nullable: false),
                    Tem_epilepsia_convulsoes = table.Column<bool>(type: "boolean", nullable: false),
                    Hiper_Hipotensao = table.Column<bool>(type: "boolean", nullable: false),
                    Problemas_cardiacos = table.Column<bool>(type: "boolean", nullable: false),
                    Em_tratamento_medico = table.Column<bool>(type: "boolean", nullable: false),
                    Problemas_de_pele = table.Column<bool>(type: "boolean", nullable: false),
                    Cirurgia_recente = table.Column<bool>(type: "boolean", nullable: false),
                    Ciclo_menstrual_regular = table.Column<bool>(type: "boolean", nullable: false),
                    Proteses_metalicas = table.Column<bool>(type: "boolean", nullable: false),
                    Possui_alergia = table.Column<bool>(type: "boolean", nullable: false),
                    Fica_muito_tempo_sentada = table.Column<bool>(type: "boolean", nullable: false),
                    Antecedentes_cirurgicos = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamneses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome_completo = table.Column<string>(type: "text", nullable: false),
                    RG = table.Column<string>(type: "text", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    CEP = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Whatsapp = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Como_nos_conheceu = table.Column<string>(type: "text", nullable: true),
                    AnamneseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Anamneses_AnamneseId",
                        column: x => x.AnamneseId,
                        principalTable: "Anamneses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo_de_servico = table.Column<string>(type: "text", nullable: false),
                    Profissional = table.Column<string>(type: "text", nullable: false),
                    Observacoes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    Sessoes = table.Column<List<bool>>(type: "boolean[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_PacienteId",
                table: "Agendas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_PacienteId",
                table: "Atendimentos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_AnamneseId",
                table: "Pacientes",
                column: "AnamneseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Anamneses");
        }
    }
}
