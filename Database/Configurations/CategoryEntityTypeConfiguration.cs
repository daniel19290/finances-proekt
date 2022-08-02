using Microsoft.EntityFrameworkCore;
using TransactionAPI.Database.Entities;

namespace TransactionAPI.Database.Configurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("category");

            builder.HasKey(x => x.Ccode);

            builder.Property(x => x.Ccode).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.parentCode).HasMaxLength(64);  
        }
    }
}
