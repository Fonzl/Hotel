using Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Data;

public class City
{
    public long Id { get; set; }
    public long CountryId { get; set; }
    public Country Country { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public List<Hotel> HotelList { get; set; } = [];
}
public class CityMap
{
public CityMap(EntityTypeBuilder<City> entityTypeBuilder)
{
    entityTypeBuilder.HasKey(e => e.Id);
    entityTypeBuilder.Property(e => e.Name).IsRequired();
    entityTypeBuilder.Property(e => e.Info).IsRequired();
    entityTypeBuilder
        .HasMany(e => e.HotelList)
        .WithOne(e => e.City)
        .HasForeignKey(e => e.CityId).IsRequired(); ;
}



}
