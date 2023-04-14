using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Employee_Terminal.Entities;

public partial class MaindbContext : DbContext
{
    public MaindbContext()
    {
    }

    public MaindbContext(DbContextOptions<MaindbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dest> Dests { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=maindb;username=maksst;password=1222");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dest>(entity =>
        {
            entity.HasKey(e => e.Ид).HasName("PRIMARY");

            entity.ToTable("dest");

            entity.HasIndex(e => e.ПользовательИд, "dest_FK");

            entity.Property(e => e.Ид).HasColumnName("ИД");
            entity.Property(e => e.ВремяПрибытия)
                .HasColumnType("text")
                .HasColumnName("Время прибытия");
            entity.Property(e => e.ВремяУбытия)
                .HasColumnType("text")
                .HasColumnName("Время убытия");
            entity.Property(e => e.Дата).HasMaxLength(50);
            entity.Property(e => e.ОкончаниеПосещения)
                .HasColumnType("text")
                .HasColumnName("Окончание посещения");
            entity.Property(e => e.ПользовательИд).HasColumnName("Пользователь ИД");
            entity.Property(e => e.РазрешениеНаТерриторию)
                .HasMaxLength(100)
                .HasColumnName("Разрешение на территорию");
            entity.Property(e => e.СотрудникИд).HasColumnName("Сотрудник ИД");
            entity.Property(e => e.СтатусЗаявки)
                .HasMaxLength(100)
                .HasColumnName("Статус Заявки");

            entity.HasOne(d => d.ПользовательИдNavigation).WithMany(p => p.Dests)
                .HasForeignKey(d => d.ПользовательИд)
                .HasConstraintName("dest_FK");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.КодСотрудника).HasName("PRIMARY");

            entity.ToTable("staff");

            entity.Property(e => e.КодСотрудника).HasColumnName("Код сотрудника");
            entity.Property(e => e.Отдел).HasMaxLength(50);
            entity.Property(e => e.Подразделение).HasMaxLength(50);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasKey(e => e.Ид).HasName("PRIMARY");

            entity.ToTable("visitor");

            entity.Property(e => e.Ид).HasColumnName("ИД");
            entity.Property(e => e.EMail)
                .HasMaxLength(50)
                .HasColumnName("E-mail");
            entity.Property(e => e.ДанныеПаспорта)
                .HasMaxLength(50)
                .HasColumnName("Данные паспорта");
            entity.Property(e => e.ДатаРождения)
                .HasMaxLength(50)
                .HasColumnName("Дата рождения");
            entity.Property(e => e.Логин).HasMaxLength(50);
            entity.Property(e => e.НомерТелефона)
                .HasMaxLength(50)
                .HasColumnName("Номер телефона");
            entity.Property(e => e.Пароль).HasMaxLength(50);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .HasColumnName("ФИО");
            entity.Property(e => e.ЧёрныйСписок)
                .HasDefaultValueSql("'0'")
                .HasColumnName("Чёрный список");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
