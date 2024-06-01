

using Data;
using DTO.HotelСhainDto;
using Microsoft.EntityFrameworkCore;


namespace Repository.RepositoryHotelСhain
{
    public class HotelChainRepository(ApplicationContext context) : IHotelChainRepository
    {
        private readonly ApplicationContext _context = context;
        private DbSet<HotelChain> _hotelchains = context.Set<HotelChain>();
        public HotelChainDto Get(long id)
        {
            var hotelchain = _hotelchains.SingleOrDefault(h => h.Id == id);
            if (hotelchain == null) return null;
            HotelChainDto chain = new HotelChainDto()
                { Id = hotelchain.Id,
                Name = hotelchain.Name,
                OwnerName = hotelchain.OwnerName
            };
            return chain;
        }
        public List<HotelChainDto> GetAll()
        {
            var hotelchains = _hotelchains.ToList();
            List<HotelChainDto> HotelСhains = new List<HotelChainDto>();
            foreach(var hotelchain in hotelchains)
            {
                HotelСhains.Add(new HotelChainDto
                {
                    Id = hotelchain.Id,
                    Name = hotelchain.Name,
                    OwnerName = hotelchain.OwnerName,

                });
            }
            return HotelСhains;
        }
       public void Insert(CreateHotelChainDto dto)
        {
            var hotelСhain = new HotelChain()
            { 
              Name = dto.Name,
              OwnerName = dto.OwnerName,
              
            };
            _hotelchains.Add(hotelСhain);
            context.SaveChanges();
        }
       public void Update(UpdateHotelChainDto dto)
        {
            var hotelchain = _hotelchains.SingleOrDefault(x => x.Id == dto.Id);
            if (hotelchain == null) return;
           
            hotelchain.Name = dto.Name;
            hotelchain.OwnerName = dto.OwnerName;

            _hotelchains.Update(hotelchain);
            context.SaveChanges();
        }
       public void Delete(long id)
        {
            var hotelchain = _hotelchains.SingleOrDefault(x => x.Id == id);
            if (hotelchain == null) return;
            _hotelchains.Remove(hotelchain);
            context.SaveChanges();
        }
    }
}
