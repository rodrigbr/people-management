using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using People.Management.Domain.Entites;

namespace People.Management.Infra.EntityMappers
{
    public class SchoolingMap : IEntityTypeConfiguration<Schooling>  
    {
        public void Configure(EntityTypeBuilder<Schooling> builder)
        {
            builder.ToTable("Schooling", "u"); 
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.ReferenceId).IsUnique();

            builder.Property(x => x.Description).HasMaxLength(100).IsRequired();

            builder.Ignore(x => x.ValidationResult);
        }
    }
}
