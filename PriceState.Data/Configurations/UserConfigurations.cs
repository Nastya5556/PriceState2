using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceState.Data.Models;

namespace PriceState.Data.Configurations;

public class UserConfigurations
{
    public UserConfigurations (EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .HasOne(x => x.Region)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RegionId); 
    }
}
