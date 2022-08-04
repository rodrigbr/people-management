using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using People.Management.Domain.Entites;

namespace People.Management.Infra.EntityMappers
{
    public class SchoolRecordMap : IEntityTypeConfiguration<SchoolRecord>
    {
        public void Configure(EntityTypeBuilder<SchoolRecord> builder)
        {
            builder.ToTable("SchoolRecord", "u");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.ReferenceId).IsUnique();

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Format).HasMaxLength(100).IsRequired();

            builder.Ignore(x => x.ValidationResult);
        }
    }
}
