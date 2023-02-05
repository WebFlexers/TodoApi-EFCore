using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data.Entities.Configuration;
public class TodosConfig : IEntityTypeConfiguration<Todos>
{
    public void Configure(EntityTypeBuilder<Todos> builder)
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
