using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DALWEFCore.Models
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IIOS2UM\\SQLEXPRESS;Database=Test;User Id=sa;Password=sa123;");
                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["EFCoreConnection"].ConnectionString.ToString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.0.0-preview.18572.1");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D5946642DAF69797");

                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleFactura)
                    .HasName("PK__DetalleF__DB5F463124244FD6");

                entity.Property(e => e.Item)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ValorItem).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ValorItems).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.DetalleFactura)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK__DetalleFa__IdFac__15502E78");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Factura__50E7BAF1D570510C");

                entity.Property(e => e.TotalFactura).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Factura__IdClien__1273C1CD");
            });
        }
    }
}
