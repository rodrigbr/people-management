using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using People.Management.Domain.Entites;
using People.Management.Domain.Statics;

namespace People.Management.Infra.EntityMappers
{
    public class SchoolingTypeMap : IEntityTypeConfiguration<SchoolingType>
    {
        public void Configure(EntityTypeBuilder<SchoolingType> builder)
        {
            builder.ToTable("ScholingType", "u");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.Ignore(x => x.ValidationResult);

            builder.HasData(SchoolingTypeStatic.DataArray());
        }
    }
}