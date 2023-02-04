using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoApi.Authentication;
using TodoApi.Data.Models;



namespace TodoApi.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<TodoItemModel> TodoItems { get; set; }
    public DbSet<TodosModel> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItemModel>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.Property(e => e.ItemName)
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(e => e.ItemDescription)
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(e => e.ItemStatus)
            .IsRequired()
            .HasMaxLength(1);
        });

        modelBuilder.Entity<TodosModel>(entity =>
        {
            entity.HasKey(e => e.TodosId);

            entity.Property(e => e.TodosName)
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(e => e.TodosDescription)
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(e => e.TodosStatus)
            .IsRequired()
            .HasMaxLength(1);
        });

        base.OnModelCreating(modelBuilder);
      
    }
}
