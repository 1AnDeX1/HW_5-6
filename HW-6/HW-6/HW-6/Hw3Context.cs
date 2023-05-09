using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HW_6;

public partial class Hw3Context : DbContext
{
    public Hw3Context()
    {
    }

    public Hw3Context(DbContextOptions<Hw3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Analysis> Analyses { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-GB7F144\\MSSQLSERVER02;Initial Catalog=HW-3;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Analysis>(entity =>
        {
            entity.HasKey(e => e.AnId).HasName("PK__Analysis__831DABF3DE3C7632");

            entity.ToTable("Analysis");

            entity.Property(e => e.AnId).HasColumnName("an_id");
            entity.Property(e => e.AnCost).HasColumnName("an_cost");
            entity.Property(e => e.AnGroup).HasColumnName("an_group");
            entity.Property(e => e.AnName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("an_name");
            entity.Property(e => e.AnPrice).HasColumnName("an_price");

            entity.HasOne(d => d.AnGroupNavigation).WithMany(p => p.Analyses)
                .HasForeignKey(d => d.AnGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Analysis__an_gro__4BAC3F29");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GrId).HasName("PK__Groups__2BC0F88EAE21336D");

            entity.Property(e => e.GrId).HasColumnName("gr_id");
            entity.Property(e => e.GrName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gr_name");
            entity.Property(e => e.GrTemp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gr_temp");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdId).HasName("PK__Orders__DC39D7DFAAADFE9A");

            entity.Property(e => e.OrdId).HasColumnName("ord_id");
            entity.Property(e => e.OrdAn).HasColumnName("ord_an");
            entity.Property(e => e.OrdDatetime)
                .HasColumnType("datetime")
                .HasColumnName("ord_datetime");

            entity.HasOne(d => d.OrdAnNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrdAn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__ord_an__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
