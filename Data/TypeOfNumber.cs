

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class TypeOfNumber
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<HotelRoom> HotelRooms { get; set;}
}
public class TypeOfNumberMap
{
    public TypeOfNumberMap(EntityTypeBuilder<TypeOfNumber> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.Id);
        entityTypeBuilder.Property(x => x.Name).IsRequired();
        entityTypeBuilder
            .HasMany(x => x.HotelRooms)
            .WithOne(x => x.TypeOfNumber)
            .HasForeignKey(x => x.TypeOfNumberId).IsRequired();
    }
}
