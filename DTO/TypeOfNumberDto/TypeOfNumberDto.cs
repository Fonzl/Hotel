using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.TypeOfNumberDto
{
    public class TypeOfNumberDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<HotelRoomDto.HotelRoomDto> HotelRooms { get; set; }
    }
}
