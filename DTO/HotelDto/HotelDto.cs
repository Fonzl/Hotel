

using Data;
using DTO.HotelСhainDto;

namespace DTO.HotelDto
{
    public class HotelDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public long CityID { get; set; }
        public CityDto.CityDto City { get; set; }
        public long? HotelСhainId { get; set; }
        public HotelСhainDto.HotelChainDto?  HotelСhain { get; set; }
        public int Stars { get; set; }
        public string Address { get; set; }
    }
}
