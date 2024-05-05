using DTO.HotelСhainDto;
using Repository.RepositoryHotelСhain;


namespace Service.ServiceHotelChain
{
    public class ServiceHotelChain(IHotelChainRepository hotelСhainRepository) : IServiceHotelChain 
    {
       public HotelChainDto GetHotelChain(long id)
        {
            return hotelСhainRepository.Get(id);
        }
       public List<HotelChainDto> GetHotelChains()
        {
            return hotelСhainRepository.GetAll();
        }
       public void InsertHotelChain(CreateHotelChainDto dto)
        {
            hotelСhainRepository.Insert(dto);
        }
        public void UpdateHotelChainm(UpdateHotelChainDto dto)
        {
            hotelСhainRepository.Update(dto);
        }
        public  void DeleteHotelChain(long id)
        {
            hotelСhainRepository.Delete(id);
        }
    }
}
