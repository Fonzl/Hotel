using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.HotelRoomDto
{
   public class HotelRoomDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long NumberOfBeds { get; set; }
        public long PricePerNight { get; set; }
        public long TypeOfNumberId { get; set; }
    }
}
