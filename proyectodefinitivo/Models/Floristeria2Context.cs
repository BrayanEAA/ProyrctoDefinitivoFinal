using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace proyectodefinitivo.Models;

public partial class Floristeria2Context : DbContext
{
    public Floristeria2Context()
    {
    }

    public Floristeria2Context(DbContextOptions<Floristeria2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-IBQL15TQ\\SQLEXPRESS;Database=Floristeria2;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__cliente__885457EE8FB35F69");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__0988921092FA299B");

            entity.ToTable("producto");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__venta__BC1240BDAE78DD8B");

            entity.ToTable("venta");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Fechapedido)
                .HasColumnType("date")
                .HasColumnName("fechapedido");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__venta__IdCliente__3A81B327");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__venta__IdProduct__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
