﻿// <auto-generated />
using AppATS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppAts.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220927124804_AlteracaoSituacaoVaga")]
    partial class AlteracaoSituacaoVaga
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppATS.Models.Candidato", b =>
                {
                    b.Property<string>("IdCandidato")
                        .HasColumnName("idCandidatos")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<short>("Ativo")
                        .HasColumnName("ativo")
                        .HasColumnType("smallint");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Login")
                        .HasColumnName("login")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Nome")
                        .HasColumnName("nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Senha")
                        .HasColumnName("senha")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("IdCandidato")
                        .HasName("pkCandidato");

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("AppATS.Models.Candidatura", b =>
                {
                    b.Property<string>("IdCandidatura")
                        .HasColumnName("IdCandidatura")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("IdCandidato")
                        .IsRequired()
                        .HasColumnName("IdCandidato")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("IdCandidatoNavigationIdCandidato")
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("IdVaga")
                        .IsRequired()
                        .HasColumnName("idVaga")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("IdVagaNavigationIdVaga")
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("IdCandidatura")
                        .HasName("pkCandidatura");

                    b.HasIndex("IdCandidato")
                        .HasName("fkcandidato_idx");

                    b.HasIndex("IdCandidatoNavigationIdCandidato");

                    b.HasIndex("IdVaga")
                        .HasName("fkvaga_idx");

                    b.HasIndex("IdVagaNavigationIdVaga");

                    b.ToTable("candidaturas");
                });

            modelBuilder.Entity("AppATS.Models.Vaga", b =>
                {
                    b.Property<string>("IdVaga")
                        .HasColumnName("idVaga")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Situacao")
                        .HasColumnName("situacao")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdVaga")
                        .HasName("pkVaga");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("AppATS.Models.Candidatura", b =>
                {
                    b.HasOne("AppATS.Models.Candidato", "IdCandidatoNavigation")
                        .WithMany()
                        .HasForeignKey("IdCandidatoNavigationIdCandidato");

                    b.HasOne("AppATS.Models.Vaga", "IdVagaNavigation")
                        .WithMany()
                        .HasForeignKey("IdVagaNavigationIdVaga");
                });
#pragma warning restore 612, 618
        }
    }
}
