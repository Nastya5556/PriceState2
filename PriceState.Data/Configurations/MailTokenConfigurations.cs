using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceState.Data.Models;

namespace PriceState.Data.Configurations;

public class MailTokenConfiguration 
{
    public MailTokenConfiguration (EntityTypeBuilder<MailToken> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.User)
            .WithMany(x => x.Tokens)
            .HasForeignKey(x => x.UserId);
    }
}