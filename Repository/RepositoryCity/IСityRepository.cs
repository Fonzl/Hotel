
using DTO.CityDto;
namespace Repository.RepositoryCity
{
 
    public interface ICityRepository
    {
        CityDto Get(long id);
        List<CityDto> GetAll();
        void Insert(CreateCityDto dto);
        void Update(UpdateCityDto dto);
        void Delete(long id);
    }
}
