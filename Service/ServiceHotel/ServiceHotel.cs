
using DTO.HotelDto;
using Repository.RepositoryHotel;


namespace Service.ServiceHotel
{
    public class ServiceHotel(IRepositoryHotel hotelRepository) : IServiceHotel
    {
        private IRepositoryHotel _hotelRepository = hotelRepository;
       public HotelDetailDto GetHotel(long id)
        {
            return _hotelRepository.Get(id);
        }
      public  List<HotelDto> GetHotels()
        {
            return _hotelRepository.GetAll();
        }
      public  void InsertHotel(CreateHotelDto dto)
        {
            _hotelRepository.Insert(dto);
        }
      public void UpdateHotel(UpdateHotelDto dto)
        {
            _hotelRepository.Update(dto);
        }
       public void DeleteHotel(long id)
        {
            _hotelRepository.Delete(id);
        }
    }
}
