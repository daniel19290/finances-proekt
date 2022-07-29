using Microsoft.EntityFrameworkCore;
using TransactionAPI.Database.Entities;

namespace TransactionAPI.Database.Configurations
{
    public class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.ToTable("transaction");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().HasMaxLength(64);
            builder.Property(x => x.BeneficiaryName).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Date);
            builder.Property(x => x.Direction).HasConversion<string>();
            builder.Property(x => x.Description).HasMaxLength(1024);
            builder.Property(x => x.Amount);
            builder.Property(x => x.Currency).HasMaxLength(8);
            builder.Property(x => x.Kind).HasConversion<string>();
            builder.Property(x => x.Mcc).HasMaxLength(128);   
        }
    }
}
