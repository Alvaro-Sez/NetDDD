using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VY.Restaurant.Data.Contracts.Data;

#nullable disable

namespace VY.Restaurant.Data.Impl.Data
{
    public partial class RestaurantDbContext : DbContext
    {

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<ClienteEntity> Clientes { get; set; }
        public virtual DbSet<GrupoEntity> Grupos { get; set; }
        public virtual DbSet<MesaEntity> Mesas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<ClienteEntity>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdGrupo).HasColumnName("Id_Grupo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Grupo");
            });

            modelBuilder.Entity<GrupoEntity>(entity =>
            {
                entity.ToTable("Grupo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HoraReserva)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MesaEntity>(entity =>
            {
                entity.HasKey(e => e.IdGrupo);

                entity.ToTable("Mesa");

                entity.Property(e => e.IdGrupo)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Grupo");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithOne(p => p.Mesa)
                    .HasForeignKey<MesaEntity>(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mesa_Grupo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
