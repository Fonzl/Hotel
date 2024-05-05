
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Country
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Info {  get; set; }
    public List<City> CityList { get; set; } = [];

}
 public class CountryMap
    {
    public CountryMap(EntityTypeBuilder<Country> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.Name).IsRequired();
        entityTypeBuilder.Property(e => e.Info).IsRequired();
        entityTypeBuilder
            .HasMany(e => e.CityList)
            .WithOne(e => e.Country)
            .HasForeignKey(e => e.CountryId).IsRequired(); ;
    }

    
    
    }
