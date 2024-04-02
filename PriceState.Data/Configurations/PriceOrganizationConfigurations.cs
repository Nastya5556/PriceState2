using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceState.Data.Models;

namespace PriceState.Data.Configurations;

public class PriceOrganizationConfigurations
{
    public PriceOrganizationConfigurations(EntityTypeBuilder<PriceOrganization> builder)
    {
        builder.HasKey(x => new { x.Date , x.OrganizationId, x.ProductId});

    builder.HasOne(x => x.Product)
            .WithMany(x => x.PriceOrganizations)
            .HasForeignKey(x => x.ProductId);
    
    builder.HasOne(x => x.Organization)
        .WithMany(x => x.PriceOrganizations)
        .HasForeignKey(x => x.OrganizationId);
    }
}
