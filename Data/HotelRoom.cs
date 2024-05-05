



using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class HotelRoom
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long NumberOfBeds {  get; set; } 
    public string Info { get; set; }
    public long PricePerNight { get; set; }
    public long IdMedia { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }    
    public long TypeOfNumberId { get; set; }
    public TypeOfNumber TypeOfNumber { get; set; }
}
public class HotelRoomMap
{
    public HotelRoomMap(EntityTypeBuilder<HotelRoom> entityTypeBuilder)
    { 
        entityTypeBuilder.HasKey(x => x.Id);
        entityTypeBuilder.Property(x => x.Name).IsRequired();
        entityTypeBuilder.Property(x => x.Info).IsRequired();
        entityTypeBuilder.Property(x => x.PricePerNight).IsRequired(); 
    }
}
