

using Data;

namespace DTO.HotelRoomDto
{
    public class UpdateHotelRoomDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long NumberOfBeds { get; set; }
        public string Info { get; set; }
        public long PricePerNight { get; set; }
        public long IdMedia { get; set; }
        public long HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public long TypeOfNumberId { get; set; }
        public TypeOfNumber TypeOfNumber { get; set; }
    }
}
