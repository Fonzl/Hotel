using Data;
using DTO.TypeOfNumberDto;
using Microsoft.EntityFrameworkCore;


namespace Repository.RepositoryTypeOfNumber
{
     public class RepositoryTypeOfNumber(ApplicationContext context) : IRepositoryTypeOfNumber
    {
        private readonly ApplicationContext _context = context;
        private DbSet<TypeOfNumber> _typeOfNumbers = context.Set<TypeOfNumber>();
       public TypeOfNumberDto Get(long id)
        {
            var type = _typeOfNumbers.SingleOrDefault( x => id == x.Id);
            if (type == null) return null;
            TypeOfNumberDto typeOfNumberDto = new TypeOfNumberDto()
            {
                Id = type.Id,
                Name = type.Name
            };
            return typeOfNumberDto;


        }
        public List<TypeOfNumberDto> GetAll()
        {
            var types = _typeOfNumbers.ToList();
            List<TypeOfNumberDto> typeOfNumberDtos = new List<TypeOfNumberDto>();
            foreach(var type in types)
            {
                typeOfNumberDtos.Add(new TypeOfNumberDto
                {
                    Id = type.Id,
                    Name = type.Name
                });
            }
            return typeOfNumberDtos;
        }
        public void Insert(CreateTypeOfNumberDto dto)
        {
            var type = new TypeOfNumber
            {
                Name = dto.Name

            };
            _typeOfNumbers.Add(type);
            context.SaveChanges();
        }
        public void Update(UpdateTypeOfNumberDto dto)
        {
            var type = _typeOfNumbers.SingleOrDefault(x => x.Id == dto.Id);
            if (type == null) return;
            type.Name = dto.Name;
            _typeOfNumbers.Update(type);
            _context.SaveChanges();
        }
        public void Delete(long id)
        {
            var type = _typeOfNumbers.SingleOrDefault(x => x.Id == id);
            if (type == null) return;
            _typeOfNumbers.Remove(type);
            context.SaveChanges();
        }

    }
}
