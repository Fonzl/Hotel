

using Data;

namespace DTO.HotelDto
{
    public class CreateHotelDto
    {
        
        public string Name { get; set; }
        public string Info { get; set; }
        public long CityID { get; set; }
        public City City { get; set; }
        public long? HotelСhainId { get; set; }
        public HotelChain? HotelСhain { get; set; }
        public int Stars { get; set; }
        public string Address { get; set; }
    }
}
