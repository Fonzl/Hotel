
using Data;

namespace DTO.CityDto;

public class CreateCityDto
{

    public long CountryId { get; set; }
    public Country Country { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
}
