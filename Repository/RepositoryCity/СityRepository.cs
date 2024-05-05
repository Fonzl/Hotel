using Data;
using DTO.CityDto;
using Microsoft.EntityFrameworkCore;

namespace Repository.RepositoryCity;

public class CityRepository(ApplicationContext context) : ICityRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<City> _cities = context.Set<City>();

   public CityDto Get(long id)
    {
        var сity = _cities.SingleOrDefault(x => x.Id == id);
        if (сity == null) return null;
        CityDto сityDto = new CityDto()
        {
            Id = сity.Id,
            Name = сity.Name,
            Info = сity.Info
        };
        return сityDto;

    }
    
  public  List<CityDto> GetAll()
    {
        var cities = _cities.ToList();
        List<CityDto> citiesDto = new List<CityDto> ();

        foreach (var city in cities)
        {
            citiesDto.Add(new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                Info = city.Info
            });
        }
        return citiesDto;
    }
    public void Insert(CreateCityDto dto)
    {
        var city = new City()
        {
            Name = dto.Name,
            Info = dto.Info
        };
        _cities.Add(city);
        context.SaveChanges();
    }
    public void Update(UpdateCityDto dto)
    {
        var city = _cities.SingleOrDefault(x => x.Id == dto.Id);
        if (city == null) return;
        city.Id = dto.Id;
        city.Name = dto.Name;
        city.Info = dto.Info;
       
        _cities.Update(city);
        context.SaveChanges();

    }

    public void Delete(long id) {
        var city = _cities.SingleOrDefault(x => x.Id == id);
        if (city == null) return ;
        _cities.Remove(city);
        context.SaveChanges();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}

