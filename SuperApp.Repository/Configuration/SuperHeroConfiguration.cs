using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperApp.Domain.SuperHeroes;

namespace SuperApp.Repository.Configuration;

public class SuperHeroConfiguration : IEntityTypeConfiguration<SuperHero>
{
    public void Configure(EntityTypeBuilder<SuperHero> builder)
    {
        builder.Property(q => q.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(q => q.FirstName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(q => q.LastName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(q => q.Place)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(q => q.Power)
            .IsRequired()
            .HasMaxLength(4000);
        
        builder.Property(q => q.Id)
            .IsRequired()
            .UseIdentityColumn();
    }
}