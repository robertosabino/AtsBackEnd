using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppATS.Models
{
  public partial class AppDbContext : DbContext
  {
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Vaga> Vagas { get; set; }

    public virtual DbSet<Candidato> Candidatos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=sabino477401;database=gsl");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.Entity<Vaga>(entity =>
      {
        entity.HasKey(e => e.IdVaga)
                  .HasName("pkVaga");

        entity.ToTable("Vagas");

        entity.Property(e => e.IdVaga)
                  .HasColumnName("idVaga")
                  .HasMaxLength(36);

        entity.Property(e => e.Situacao)
                  .HasColumnName("situacao")
                  .HasMaxLength(50);
      });

      modelBuilder.Entity<Candidato>(entity =>
      {
        entity.HasKey(e => e.IdCandidato)
                  .HasName("pkCandidato");

        entity.ToTable("Candidatos");

        entity.Property(e => e.IdCandidato)
                  .HasColumnName("idCandidatos")
                  .HasMaxLength(36);

        entity.Property(e => e.Email)
                  .HasColumnName("email")
                  .HasMaxLength(250);

        entity.Property(e => e.Login)
                  .HasColumnName("login")
                  .HasMaxLength(80);

        entity.Property(e => e.Nome)
                  .HasColumnName("nome")
                  .HasMaxLength(100);

        entity.Property(e => e.Senha)
                  .HasColumnName("senha")
                  .HasMaxLength(80);
      });

      modelBuilder.Entity<Candidatura>(entity =>
      {
        entity.HasKey(e => e.IdCandidatura)
            .HasName("pkCandidatura");

        entity.ToTable("candidaturas");

        entity.HasIndex(e => e.IdVaga)
            .HasName("fkvaga_idx");

        entity.HasIndex(e => e.IdCandidato)
            .HasName("fkcandidato_idx");

        entity.Property(e => e.IdCandidatura)
            .HasColumnName("IdCandidatura")
            .HasMaxLength(36);

        entity.Property(e => e.IdVaga)
            .IsRequired()
            .HasColumnName("idVaga")
            .HasMaxLength(36);

        entity.Property(e => e.IdCandidato)
            .IsRequired()
            .HasColumnName("IdCandidato")
            .HasMaxLength(36);
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
