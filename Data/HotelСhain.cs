

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class HotelСhain
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string OwnerName { get; set; }
    public long IdMedia {  get; set; }  
    public List<Hotel> Hotel { get; set; }

}
public class HotelChainMap
{
   public HotelChainMap(EntityTypeBuilder<HotelСhain> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.Id);
        entityTypeBuilder.Property(x => x.Name).IsRequired();
        entityTypeBuilder.Property(x=> x.OwnerName).IsRequired();
        entityTypeBuilder
             .HasMany(x => x.Hotel)
            .WithOne(x => x.HotelСhain)
            .HasForeignKey(x => x.HotelСhainId).IsRequired();

    }
}

