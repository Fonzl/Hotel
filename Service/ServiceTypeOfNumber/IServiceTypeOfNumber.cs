using DTO.HotelRoomDto;
using DTO.TypeOfNumberDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceTypeOfNumber
{
    public interface IServiceTypeOfNumber
    {
        TypeOfNumberDto GetTypeOfNumber(long id);
        List<TypeOfNumberDto> GetTypeOfNumbers();
        void InsertTypeOfNumber(CreateTypeOfNumberDto dto);
        void UpdateTypeOfNumber(UpdateTypeOfNumberDto dto);
        void DeleteTypeOfNumber(long id);
    }
}
