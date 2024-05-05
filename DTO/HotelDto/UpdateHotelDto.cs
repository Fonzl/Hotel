

using Data;

namespace DTO.HotelDto
{
    public class UpdateHotelDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public long CityID { get; set; }
        public City City { get; set; }
        public long? HotelСhainId { get; set; }
        public HotelСhain? HotelСhain { get; set; }
        public long IdMedia { get; set; }
    }
}
