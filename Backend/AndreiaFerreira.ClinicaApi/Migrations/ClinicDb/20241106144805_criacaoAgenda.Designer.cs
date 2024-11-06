﻿// <auto-generated />
using System;
using System.Collections.Generic;
using AndreiaFerreira.ClinicaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AndreiaFerreira.ClinicaApi.Migrations.ClinicDb
{
    [DbContext(typeof(ClinicDbContext))]
    [Migration("20241106144805_criacaoAgenda")]
    partial class criacaoAgenda
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AndreiaFerreira.ClinicaApi.Models.Entities.AgendaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Observacoes")
                        .HasColumnType("text");

                    b.Property<int>("PacienteId")
                        .HasColumnType("integer");

                    b.Property<string>("Profissional")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tipo_de_servico")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("AndreiaFerreira.ClinicaApi.Models.Entities.AnamneseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Alimentacao_balanceada")
                        .HasColumnType("boolean");

                    b.Property<bool>("Antecedentes_cirurgicos")
                        .HasColumnType("boolean");

                    b.Property<bool>("Antecedentes_oncologicos")
                        .HasColumnType("boolean");

                    b.Property<bool>("Ciclo_menstrual_regular")
                        .HasColumnType("boolean");

                    b.Property<bool>("Cirurgia_recente")
                        .HasColumnType("boolean");

                    b.Property<bool>("Cuidados_diarios_com_a_pele")
                        .HasColumnType("boolean");

                    b.Property<bool>("Diabetes")
                        .HasColumnType("boolean");

                    b.Property<bool>("Disturbio_circulatorio")
                        .HasColumnType("boolean");

                    b.Property<bool>("Disturbio_hormonal")
                        .HasColumnType("boolean");

                    b.Property<bool>("Em_tratamento_medico")
                        .HasColumnType("boolean");

                    b.Property<bool>("Esta_gravida")
                        .HasColumnType("boolean");

                    b.Property<bool>("Esta_menstruada")
                        .HasColumnType("boolean");

                    b.Property<bool>("Fica_muito_tempo_sentada")
                        .HasColumnType("boolean");

                    b.Property<bool>("Fumante")
                        .HasColumnType("boolean");

                    b.Property<bool>("Funcionamento_intestinal_regular")
                        .HasColumnType("boolean");

                    b.Property<bool>("Hiper_Hipotensao")
                        .HasColumnType("boolean");

                    b.Property<bool>("Ingere_agua")
                        .HasColumnType("boolean");

                    b.Property<bool>("Ingere_bebida_alcoolica")
                        .HasColumnType("boolean");

                    b.Property<bool>("Medicamentos_de_uso_diario")
                        .HasColumnType("boolean");

                    b.Property<bool>("Possui_alergia")
                        .HasColumnType("boolean");

                    b.Property<bool>("Pratica_atividade_fisica")
                        .HasColumnType("boolean");

                    b.Property<bool>("Problemas_cardiacos")
                        .HasColumnType("boolean");

                    b.Property<bool>("Problemas_de_pele")
                        .HasColumnType("boolean");

                    b.Property<bool>("Problemas_ortopedicos")
                        .HasColumnType("boolean");

                    b.Property<bool>("Proteses_metalicas")
                        .HasColumnType("boolean");

                    b.Property<bool>("Tem_epilepsia_convulsoes")
                        .HasColumnType("boolean");

                    b.Property<bool>("Varizes_ou_Lesoes")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Anamneses");
                });

            modelBuilder.Entity("AndreiaFerreira.ClinicaApi.Models.Entities.ClientModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AnamneseId")
                        .HasColumnType("integer");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Como_nos_conheceu")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome_completo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Whatsapp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnamneseId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("AndreiaFerreira.ClinicaApi.Models.Entities.CustomerTreatmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PacienteId")
                        .HasColumnType("integer");

                    b.Property<List<bool>>("Sessoes")
                        .IsRequired()
                        .HasColumnType("boolean[]");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("AndreiaFerreira.ClinicaApi.Models.Entities.AgendaModel", b =>
                {
                    b.HasOne("AndreiaFerreira.ClinicaApi.Models.Entities.ClientModel", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("AndreiaFerreira.ClinicaApi.Models.Entities.ClientModel", b =>
                {
                    b.HasOne("AndreiaFerreira.ClinicaApi.Models.Entities.AnamneseModel", "Anamnese")
                        .WithMany()
                        .HasForeignKey("AnamneseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anamnese");
                });

            modelBuilder.Entity("AndreiaFerreira.ClinicaApi.Models.Entities.CustomerTreatmentModel", b =>
                {
                    b.HasOne("AndreiaFerreira.ClinicaApi.Models.Entities.ClientModel", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
