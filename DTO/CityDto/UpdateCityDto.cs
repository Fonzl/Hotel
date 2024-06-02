
using Data;

namespace DTO.CityDto;

public class UpdateCityDto
{
    public long Id { get; set; }
    public long CountryId { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
}
