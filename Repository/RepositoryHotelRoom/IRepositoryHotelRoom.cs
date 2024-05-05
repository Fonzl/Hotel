using Data;
using DTO.HotelRoomDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryHotelRoom
{
    public interface IRepositoryHotelRoom
    {
        HotelRoomDto Get(long id);
        List<HotelRoomDto> GetAll();
        void Insert(CreateHotelRoomDto dto);
        void Update(UpdateHotelRoomDto dto);
        void Delete(long id);

    }
}
