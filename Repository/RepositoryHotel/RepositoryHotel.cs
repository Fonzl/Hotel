

using Data;
using DTO.HotelDto;
using DTO.HotelRoomDto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository.RepositoryHotel
{
   
        public class RepositoryHotel(ApplicationContext context) : IRepositoryHotel
        {
            private readonly ApplicationContext _context = context;
            private DbSet<Hotel> _hotels = context.Set<Hotel>();
            private DbSet<HotelRoom> _hotelrooms = context.Set<HotelRoom>();


        public HotelDto Get(long id)
            {
                var hotel = _hotels.Include( x => x.HotelRooms).SingleOrDefault(x => x.Id == id);
            if (hotel == null) return null;
            return new HotelDto
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Info = hotel.Info,
                Stars = hotel.Stars,
                Address = hotel.Address,
                HotelRooms = hotel.HotelRooms.Select(r => new HotelRoomDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    NumberOfBeds = r.NumberOfBeds,
                    PricePerNight = r.PricePerNight
                }).ToList()


            };

                
           
                //if (hotel == null) return null;
                //HotelDto hotelDto = new HotelDto()
                //{
                //    Id = hotel.Id,
                //    Name = hotel.Name,
                //    Info = hotel.Info,
                //    Stars = hotel.Stars,
                //    Address = hotel.Address,


            //};
            //return hotelDto;

            }

            public List<HotelDto> GetAll()
            {
                var hotels = _hotels.ToList();
                List<HotelDto> hotelsDto = new List<HotelDto>();

                foreach (var hotel in hotels)
                {
                    hotelsDto.Add(new HotelDto
                    {
                        Id = hotel.Id,
                        Name = hotel.Name,
                        Stars = hotel.Stars,
                        Address = hotel.Address,
                    });
                }
                return hotelsDto;
            }
            public void Insert(CreateHotelDto dto)
            {
                var hotel = new Hotel()
                {
                    Name = dto.Name,
                    Info = dto.Info,
                    Stars = dto.Stars,
                    Address = dto.Address,
                    CityId = dto.CityID,
                    HotelСhainId = dto.HotelСhainId
                    
                };
                _hotels.Add(hotel);
                context.SaveChanges();
            }
            public void Update(UpdateHotelDto dto)
            {
                var hotel = _hotels.SingleOrDefault(x => x.Id == dto.Id);
                if (hotel == null) return;
                
                hotel.Name = dto.Name;
                hotel.Info = dto.Info;
                hotel.Stars = dto.Stars;
                hotel.Address = dto.Address;
                hotel.CityId = dto.CityID;
                hotel.HotelСhainId = dto.HotelСhainId;
                _hotels.Update(hotel);
                context.SaveChanges();

            }

            public void Delete(long id)
            {
                var hotel = _hotels.SingleOrDefault(x => x.Id == id);
                if (hotel == null) return;
                _hotels.Remove(hotel);
                context.SaveChanges();
            }

            public void SaveChanges()
            {
                context.SaveChanges();
            }
        }
    }

