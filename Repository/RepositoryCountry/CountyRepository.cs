using Data;
using DTO.CountryDto;
using Microsoft.EntityFrameworkCore;

namespace Repository.RepositoryCountry;

public class CountryRepository(ApplicationContext context) : ICountryRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Country> _countries = context.Set<Country>();

   public CountryDto Get(long id)
    {
        var country = _countries.SingleOrDefault(x => x.Id == id);
        if (country == null) return null;
        CountryDto countryDto = new CountryDto()
        {
            Id = country.Id,
            Name = country.Name,
            Info = country.Info
        };
        return countryDto;

    }
    
  public  List<CountryDto> GetAll()
    {
        var countries = _countries.ToList();
        List<CountryDto> сountriesDto = new List<CountryDto> ();

        foreach (var country in countries)
        {
            сountriesDto.Add(new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
                Info = country.Info
            });
        }
        return сountriesDto;
    }
    public void Insert(CreateCountryDto dto)
    {
        var country = new Country()
        {
            Name = dto.Name,
            Info = dto.Info
        };
         _countries.Add(country);
        context.SaveChanges();
    }
    public void Update(UpdateCountryDto dto)
    {
        var country = _countries.SingleOrDefault(b => b.Id == dto.Id);

        if (country == null) return;
       
        country.Name = dto.Name;
        country.Info = dto.Info;
                
        
        _countries.Update(country);
        context.SaveChanges();

    }

    public void Delete(long id) {
        var country = _countries.SingleOrDefault(x => x.Id == id);
        if (country == null) return ;
        _countries.Remove(country);
        context.SaveChanges();
    }
    


}

    