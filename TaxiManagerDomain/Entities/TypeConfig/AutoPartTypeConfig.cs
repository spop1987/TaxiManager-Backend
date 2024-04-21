using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiManagerDomain.Shared;

namespace TaxiManagerDomain.Entities.TypeConfig
{
    public class AutoPartTypeConfig : IEntityTypeConfiguration<AutoPart>
    {
        public void Configure(EntityTypeBuilder<AutoPart> builder)
        {
            builder.ToTable("AutoPart");
            builder.HasKey(ap => ap.Id);
            builder.Property(ap => ap.AutoPartName).IsRequired().HasColumnType("varchar(50)");
            builder.OwnsOne(ap => ap.Price, priceBuilder => 
            {
                priceBuilder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency. FromCode(code)).HasColumnType("varchar(3)");
            });
            builder.HasOne(ap => ap.Maintenance).WithMany(m => m.AutoParts).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ap => ap.WhereItWasPurchased).WithOne(a => a.AutoPart).HasForeignKey<Address>(a => a.AutoPartId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}