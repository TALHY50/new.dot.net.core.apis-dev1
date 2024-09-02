using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder) 
    { 
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("imt_countries");

        builder.Property(e => e.Id).HasColumnName("id");
        
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .HasColumnName("name");
        
        builder.Property(e => e.OfficialStateName)
            .HasMaxLength(100)
            .HasColumnName("official_state_name");
        
        builder.Property(e => e.IsoCode)
            .HasMaxLength(100)
            .HasColumnName("iso_code");
        
                
        builder.Property(e => e.IsoCodeShort)
            .HasMaxLength(100)
            .HasColumnName("iso_code_short");

        
        
        builder.Property(e => e.IsoCodeNum)
            .HasMaxLength(4)
            .HasColumnName("iso_code_num");

        
        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime")
            .HasColumnName("created_at");
        
        builder.Property(e => e.CreatedById).HasColumnName("created_by_id");
        

        
        builder.Property(e => e.Status)
            .HasDefaultValueSql("'1'")
            .HasComment("1=active, 0=inactive, 2=soft-deleted")
            .HasColumnName("status");
        
        builder.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");
        builder.Property(e => e.UpdatedById).HasColumnName("updated_by_id"); 
    }
}
