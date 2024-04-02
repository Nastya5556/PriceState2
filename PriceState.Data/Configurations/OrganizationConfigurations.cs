using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceState.Data.Models;

namespace PriceState.Data.Configurations;

public class OrganizationConfigurations
{
    public OrganizationConfigurations(EntityTypeBuilder<Organization> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .HasOne(x => x.Region)
            .WithMany(x => x.Organizations)
            .HasForeignKey(x => x.RegionId); 
        
        
   
    }
}