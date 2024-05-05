

using DTO.TypeOfNumberDto;

namespace Repository.RepositoryTypeOfNumber;

public interface IRepositoryTypeOfNumber
{
    TypeOfNumberDto Get(long id);
    List<TypeOfNumberDto> GetAll();
    void Insert(CreateTypeOfNumberDto dto);
    void Update(UpdateTypeOfNumberDto dto);
    void Delete(long id);
}
