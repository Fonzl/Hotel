using Data;
using DTO.HotelRoomDto;
using Microsoft.EntityFrameworkCore;


namespace Repository.RepositoryHotelRoom
{
    public class RepositoryHotelRoom(ApplicationContext context) : IRepositoryHotelRoom
    {
        private readonly ApplicationContext _context = context;
        private DbSet<HotelRoom> _hotelrooms = context.Set<HotelRoom>();
     

        public HotelRoomDto Get(long id)
        {
            var room = _hotelrooms.SingleOrDefault(x => x.Id == id);
            if (room == null) return null;
            HotelRoomDto hotelRoom = new HotelRoomDto()
            {
                Id = room.Id,
                Name = room.Name,
                Info = room.Info,
                NumberOfBeds = room.NumberOfBeds,
                PricePerNight = room.PricePerNight,
                TypeOfNumberId = room.TypeOfNumberId,
                HotelId = room.HotelId,
            };
            return hotelRoom;

        }
        public List<HotelRoomDto> GetAll() 
        {
            var hotelrooms = _hotelrooms.ToList();
            List<HotelRoomDto> hotelRoomsdto = new List<HotelRoomDto>();
            foreach(var hotelRoom in hotelrooms)
            {
                hotelRoomsdto.Add(new HotelRoomDto
                {
                    Id = hotelRoom.Id,
                    Name = hotelRoom.Name,
                    NumberOfBeds = hotelRoom.NumberOfBeds,
                    PricePerNight = hotelRoom.PricePerNight,
                    TypeOfNumberId = hotelRoom.TypeOfNumberId
                }); 
            }
            return hotelRoomsdto;
        }
        public void Insert(CreateHotelRoomDto dto)
        {
            var hotelroom = new HotelRoom()
            {
                Name = dto.Name,
                Info = dto.Info,
                NumberOfBeds = dto.NumberOfBeds,
                PricePerNight = dto.PricePerNight,
                HotelId = dto.HotelId,
                TypeOfNumberId = dto.TypeOfNumberId
                
            };
            _hotelrooms.Add(hotelroom);
            context.SaveChanges();
        }
        public void Update(UpdateHotelRoomDto dto)
        {
            var hotelroom = _hotelrooms.SingleOrDefault(x => x.Id == dto.Id);
            if (hotelroom == null) return;
            
            hotelroom.Name = dto.Name;
            hotelroom.Info = dto.Info;
            hotelroom.NumberOfBeds = dto.NumberOfBeds;
            hotelroom.PricePerNight = dto.PricePerNight;
            _hotelrooms.Update(hotelroom);
            context.SaveChanges();

        }

        public void Delete(long id)
        {
            var hotelroom = _hotelrooms.SingleOrDefault(x => x.Id == id);
            if (hotelroom == null) return;
            _hotelrooms.Remove(hotelroom);
            context.SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public List<HotelRoomDto> GetAllHotelRooms(long id)
        {
            var HotelRooms = _hotelrooms.Where( x => x.HotelId == id);
            if (HotelRooms == null) return null;
            List<HotelRoomDto> hotelRoomsdto = new List<HotelRoomDto>();
            foreach (var hotelRoom in HotelRooms)
            {
                hotelRoomsdto.Add(new HotelRoomDto
                {
                    Id = hotelRoom.Id,
                    Name = hotelRoom.Name,
                    NumberOfBeds = hotelRoom.NumberOfBeds,
                    PricePerNight = hotelRoom.PricePerNight,
                    TypeOfNumberId = hotelRoom.TypeOfNumberId
                });
            }
            return hotelRoomsdto;
        }
    }
}
