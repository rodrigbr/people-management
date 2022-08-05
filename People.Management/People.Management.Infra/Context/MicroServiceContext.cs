
using Microsoft.EntityFrameworkCore;
using People.Management.Domain.Entites;
using People.Management.Infra.EntityMappers;

namespace People.Management.Infra.Context
{
    public class MicroServiceContext : DbContext
    {
        public MicroServiceContext(DbContextOptions<MicroServiceContext> options)
            : base(options)
        {
        }

        public DbSet<User?> Users { get; set; }
        public DbSet<Schooling> Schoolings { get; set; }
        public DbSet<SchoolRecord> SchoolRecords { get; set; }
        public DbSet<SchoolingType> SchoolingTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("ReferenceId");
            modelBuilder.Entity<User>()
                .Property(o => o.ReferenceId)
                .HasDefaultValueSql("NEXT VALUE FOR ReferenceId");

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new SchoolingTypeMap());
            modelBuilder.ApplyConfiguration(new SchoolRecordMap());
            modelBuilder.ApplyConfiguration(new SchoolingMap());
        }
    }
}
