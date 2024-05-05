
using DTO.CountryDto;
namespace Repository.RepositoryCountry
{
      public interface ICountryRepository
    {
        CountryDto Get(long id);
        List<CountryDto> GetAll();
        void Insert(CreateCountryDto dto);
        void Update(UpdateCountryDto dto);
        void Delete(long id);
    }
}
