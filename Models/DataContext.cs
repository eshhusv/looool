using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace looool.Models;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Executor> Executors { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Assignment> Assignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB8529CD5970");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Executor>(entity =>
        {
            entity.HasKey(e => e.ExecutorId).HasName("PK__Executor__ED72B2D82AB7C517");

            entity.ToTable("Executor");

            entity.Property(e => e.ExecutorId)
                .ValueGeneratedNever()
                .HasColumnName("executor_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__BC799E1FB3E2E519");

            entity.Property(e => e.ProjectId)
                .ValueGeneratedNever()
                .HasColumnName("project_id");
            entity.Property(e => e.PeriodOfExecution).HasColumnName("period_of_execution");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("project_name");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.TaskId).HasColumnName("task_id");

            entity.HasOne(d => d.ProjectNavigation).WithOne(p => p.Project)
                .HasForeignKey<Project>(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Projects__projec__2B3F6F97");

            entity.HasOne(d => d.Project1).WithOne(p => p.Project)
                .HasForeignKey<Project>(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Projects__projec__2A4B4B5E");
        });

        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Task__0492148D53392B4D");

            entity.ToTable("Task");

            entity.Property(e => e.TaskId)
                .ValueGeneratedNever()
                .HasColumnName("task_id");
            entity.Property(e => e.TaskName)
                .HasMaxLength(255)
                .HasColumnName("task_name");

            entity.HasOne(d => d.TaskNavigation).WithOne(p => p.Task)
                .HasForeignKey<Assignment>(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Task__task_id__2C3393D0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
