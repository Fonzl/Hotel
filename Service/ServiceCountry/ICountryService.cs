using DTO.CountryDto;

namespace Service.ServiceCountry
{
    public interface ICountryService
    {
        CountryDto GetCountry(long id);
        List<CountryDto> GetCountries();
        void InsertCountry(CreateCountryDto dto);
        void UpdateCountry(UpdateCountryDto dto);
        void DeleteCountry(long id);

    }
}
