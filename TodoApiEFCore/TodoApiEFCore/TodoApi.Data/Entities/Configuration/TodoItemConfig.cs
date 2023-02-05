using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoApi.Data.Entities.Configuration;
public class TodoItemConfig : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.Property(ti => ti.Name)
            .IsRequired(true)
            .HasMaxLength(100);

        builder.Property(ti => ti.Description)
            .IsRequired(true)
            .HasMaxLength(100);

        builder.Property(ti => ti.Status)
            .IsRequired(true);
    }
}
