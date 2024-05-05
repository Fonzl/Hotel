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
                PricePerNight = room.PricePerNight
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
                    Info = hotelRoom.Info,
                    NumberOfBeds = hotelRoom.NumberOfBeds,
                    PricePerNight = hotelRoom.PricePerNight
                }); 
            }
            return hotelRoomsdto;
        }
        public void Insert(CreateHotelRoomDto dto)
        {
            var hotelroom = new HotelRoom()
            {
                Name = dto.Name,
                Info = dto.Info
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
    }
}
