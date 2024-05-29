using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaxiManagerDomain.Entities.TypeConfig
{
    public class AddressTypeConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Street).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(a => a.City).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(a => a.State).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(a => a.Zipcode).IsRequired().HasColumnType("varchar").HasMaxLength(10);
            builder.Property(a => a.CreateDate).HasColumnType("dateTime");
            builder.Property(a => a.UpdateDate).HasColumnType("dateTime");
            builder.Property(a => a.DeleteDate).HasColumnType("dateTime");
            builder.HasOne(a => a.User).WithMany(u => u.Addresses).OnDelete(DeleteBehavior.Cascade);
        }
    }
}