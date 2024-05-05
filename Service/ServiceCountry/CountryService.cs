using DTO.CountryDto;
using Repository.RepositoryCountry;

namespace Service.ServiceCountry
{
    public class CountryService(ICountryRepository countrykRepository) : ICountryService
    {
        private ICountryRepository _countrykRepository = countrykRepository;
        public CountryDto GetCountry(long id)
        {
            return _countrykRepository.Get(id);
        }

        public List<CountryDto> GetCountries()
        {
            return _countrykRepository.GetAll();
        }

        public void InsertCountry(CreateCountryDto dto)
        {
            _countrykRepository.Insert(dto);
        }

        public void UpdateCountry(UpdateCountryDto dto)
        {
            _countrykRepository.Update(dto);
        }

        public void DeleteCountry(long id)
        {
            _countrykRepository.Delete(id);
        }
    }
}
