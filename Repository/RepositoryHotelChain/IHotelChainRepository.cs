using DTO.HotelRoomDto;
using DTO.HotelСhainDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryHotelСhain
{
    public interface IHotelChainRepository
    {
        HotelChainDto Get(long id);
        List<HotelChainDto> GetAll();
        void Insert(CreateHotelChainDto dto);
        void Update(UpdateHotelChainDto dto);
        void Delete(long id);
    }
}
