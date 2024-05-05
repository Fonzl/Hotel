using DTO.CityDto;
using Repository.RepositoryCity;
using Service.ServiceCity;

namespace Service.ServiceCity
{
    public class CityService(ICityRepository cityRepository) : ICityService
    {
        private ICityRepository _cityRepository = cityRepository;
        public CityDto GetCity(long id)
        {
            return _cityRepository.Get(id);
        }

        public List<CityDto> GetCities()
        {
            return _cityRepository.GetAll();
        }

        public void InsertCity(CreateCityDto dto)
        {
            _cityRepository.Insert(dto);
        }

        public void UpdateCity(UpdateCityDto dto)
        {
            _cityRepository.Update(dto);
        }

        public void DeleteCity(long id)
        {
            _cityRepository.Delete(id);
        }
    }
}
