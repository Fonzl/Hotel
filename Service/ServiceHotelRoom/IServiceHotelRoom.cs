
using DTO.HotelRoomDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceHotelRoom
{
    public interface IServiceHotelRoom
    {

        HotelRoomDto GetHotelRoom(long id);
        List<HotelRoomDto> GetHotelRooms();
        void InsertHotelRoom(CreateHotelRoomDto dto);
        void UpdateHotelRoom(UpdateHotelRoomDto dto);
        void DeleteHotelRoom(long id);
    }
}
