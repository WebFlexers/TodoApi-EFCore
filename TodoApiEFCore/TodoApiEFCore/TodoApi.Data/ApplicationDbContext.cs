using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data.Authentication;
using TodoApi.Data.Entities;

namespace TodoApi.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<Todos> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Todos>().HasMany(td => td.TodoItems);// 1 -> many
       
        modelBuilder.Entity<TodoItem>(entity =>
        {
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

        modelBuilder.Entity<Todos>(entity =>
        {
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
