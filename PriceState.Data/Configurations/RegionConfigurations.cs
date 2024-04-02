using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceState.Data.Models;

namespace PriceState.Data.Configurations;

public class RegionConfigurations
{
    public RegionConfigurations(EntityTypeBuilder<Region> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
