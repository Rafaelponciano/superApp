using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperApp.Domain.User;

namespace SuperApp.Repository.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(q => q.FirstName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(q => q.LastName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(q => q.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(q => q.Email)
            .IsUnique();
        
        builder.Property(q => q.Password)
            .IsRequired()
            .HasMaxLength(4000);
        
        builder.Property(q => q.Id)
            .IsRequired()
            .UseIdentityColumn();
    }
}