using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceState.Data.Models;

namespace PriceState.Data.Configurations;

public class ProductConfigurations
{
    public ProductConfigurations (EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Unit)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.UnitId);
        

    }
}
