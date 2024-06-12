
using DTO.HotelDto;

namespace Repository.RepositoryHotel
{
    public interface IRepositoryHotel
    {
        HotelDetailDto Get(long id);
        List<HotelDto> GetAll();
        void Insert(CreateHotelDto dto);
        void Update(UpdateHotelDto dto);
        void Delete(long id);

    }
}
