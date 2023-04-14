using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Guard.Entities;

public partial class GuarddbContext : DbContext
{
    public GuarddbContext()
    {
    }

    public GuarddbContext(DbContextOptions<GuarddbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;DataBase=guarddb;username=maksst;password=1222");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Ид).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Ид).HasColumnName("ИД");
            entity.Property(e => e.ДобавлениеДанных)
                .HasMaxLength(100)
                .HasColumnName("Добавление данных");
            entity.Property(e => e.Должность).HasMaxLength(50);
            entity.Property(e => e.Логин).HasMaxLength(50);
            entity.Property(e => e.Одобрен).HasMaxLength(100);
            entity.Property(e => e.Пароль).HasMaxLength(50);
            entity.Property(e => e.Пол).HasMaxLength(50);
            entity.Property(e => e.ПросмотрДанных)
                .HasMaxLength(100)
                .HasColumnName("Просмотр данных");
            entity.Property(e => e.СекретноеСлово)
                .HasMaxLength(50)
                .HasColumnName("Секретное слово");
            entity.Property(e => e.ТипПользователя)
                .HasMaxLength(50)
                .HasColumnName("Тип пользователя");
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .HasColumnName("ФИО");
            entity.Property(e => e.ФормированиеОтчётов)
                .HasMaxLength(100)
                .HasColumnName("Формирование отчётов");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
