
using Data;

namespace DTO.HotelRoomDto
{
    public class CreateHotelRoomDto
    {
  
        public string Name { get; set; }
        public long NumberOfBeds { get; set; }
        public string Info { get; set; }
        public long PricePerNight { get; set; }
        public long HotelId { get; set; }
        public long TypeOfNumberId { get; set; }
    }
}
