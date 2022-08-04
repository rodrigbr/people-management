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

            builder.Ignore(x => x.ValidationResult);

            builder
                .HasOne(x => x.Description)
                .WithMany()
                .HasForeignKey(x => x.SchoolingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
