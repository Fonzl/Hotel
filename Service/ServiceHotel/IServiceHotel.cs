using DTO.HotelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceHotel
{
    public interface IServiceHotel
    {
        HotelDetailDto GetHotel(long id);
        List<HotelDto> GetHotels();
        void InsertHotel(CreateHotelDto dto);
        void UpdateHotel(UpdateHotelDto dto);
        void DeleteHotel(long id);
    }
}
