

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using People.Management.Domain.Entites;

namespace People.Management.Infra.EntityMappers
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "u");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();

            builder.Ignore(x => x.ValidationResult);

            builder.OwnsOne(
                x => x.AdressInformation,
                b =>
                {
                    b.Property(o => o.Adress).HasColumnName("Adress").HasMaxLength(100);
                    b.Property(o => o.City).HasColumnName("City").HasMaxLength(100);
                    b.Property(o => o.Country).HasColumnName("Country").HasMaxLength(100);
                    b.Property(o => o.Number).HasColumnName("Number").HasMaxLength(100);
                    b.Property(o => o.Uf).HasColumnName("Uf").HasMaxLength(100);
                    b.Property(o => o.ZipCode).HasColumnName("ZipCode").HasMaxLength(100);
                });

            #region RELATIONSHIPS

           
           

            #endregion
        }
    }
}
