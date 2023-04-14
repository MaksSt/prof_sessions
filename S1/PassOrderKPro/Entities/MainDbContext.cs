using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PassOrderKPro.Entities;

public partial class MainDbContext : DbContext
{
    public MainDbContext()
    {
    }

    public MainDbContext(DbContextOptions<MainDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SoloUser> SoloUsers { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<TeamUser> TeamUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;username=maksst;password=1222;DataBase=MainDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SoloUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("solo_users");

            entity.Property(e => e.Birtday).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("FIO");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Passport).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Time).HasMaxLength(50);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("staff");

            entity.Property(e => e.Depart).HasMaxLength(50);
            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("FIO");
            entity.Property(e => e.Unit).HasMaxLength(50);
        });

        modelBuilder.Entity<TeamUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("team_users");

            entity.Property(e => e.Birtday).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("FIO");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Passport).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Team).HasMaxLength(50);
            entity.Property(e => e.Time).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
