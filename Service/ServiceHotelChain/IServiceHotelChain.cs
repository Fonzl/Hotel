

using DTO.HotelСhainDto;


namespace Service.ServiceHotelChain
{
    public interface IServiceHotelChain
    {
        HotelChainDto GetHotelChain(long id);
        List<HotelChainDto> GetHotelChains();
        void InsertHotelChain(CreateHotelChainDto dto);
        void UpdateHotelChainm(UpdateHotelChainDto dto);
        void DeleteHotelChain(long id);
        
    }
}
