using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceState.Data.Models;

namespace PriceState.Data.Configurations;

public class UnitConfigurations
{
    public UnitConfigurations(EntityTypeBuilder<Unit> builder)
    {
        builder.HasKey(x => x.Id);

    }
}
