using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using TodoApi.Authentication;
using TodoApi.Data.Authentication;
using TodoApi.Data.Entities;



namespace TodoApi.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TodoItemEntity> TodoItems { get; set; }
    public DbSet<TodosEntity> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodosEntity>().HasMany(td => td.TodoItems);// 1 -> many
       
        modelBuilder.Entity<TodoItemEntity>(entity =>
        {
            entity.HasKey(e => e.Id);


            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(e => e.Status)
            .IsRequired()
            .HasMaxLength(1);
        });

        modelBuilder.Entity<TodosEntity>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(e => e.Status)
            .IsRequired()
            .HasMaxLength(1);
        });

        base.OnModelCreating(modelBuilder);
      
    }
}
