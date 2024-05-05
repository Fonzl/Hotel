using DTO.TypeOfNumberDto;
using Repository.RepositoryTypeOfNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceTypeOfNumber
{
    public class ServiceTypeOfNumber(IRepositoryTypeOfNumber repositoryTypeOfNumber) : IServiceTypeOfNumber
    {
       public TypeOfNumberDto GetTypeOfNumber(long id)
        {
            return repositoryTypeOfNumber.Get(id);
        }
       public List<TypeOfNumberDto> GetTypeOfNumbers()
        {
            return repositoryTypeOfNumber.GetAll(); 
        }
      public  void InsertTypeOfNumber(CreateTypeOfNumberDto dto)
        {
            repositoryTypeOfNumber.Insert(dto);
        }
       public void UpdateTypeOfNumber(UpdateTypeOfNumberDto dto)
        {
            repositoryTypeOfNumber.Update(dto);
        }
       public void DeleteTypeOfNumber(long id)
        {
            repositoryTypeOfNumber.Delete(id);
        }
    }
}
