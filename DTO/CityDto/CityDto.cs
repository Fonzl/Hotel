
using Data;

namespace DTO.CityDto
{
    public class CityDto
    {
        public long Id { get; set; }
        public long CountryId { get; set; }
        public CountryDto.CountryDto Country { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
    }
}
