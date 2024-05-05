using DTO.CityDto;

namespace Service.ServiceCity
{
    public interface ICityService
    {
        CityDto GetCity(long id);
        List<CityDto> GetCities();
        void InsertCity(CreateCityDto dto);
        void UpdateCity(UpdateCityDto dto);
        void DeleteCity(long id);

    }
}
