
using DTO.HotelRoomDto;
using Repository.RepositoryHotelRoom;


namespace Service.ServiceHotelRoom
{
    public class ServiceHotelRoom(IRepositoryHotelRoom repositoryHotelRoom) :IServiceHotelRoom
    {
        IRepositoryHotelRoom _repositoryHotelRoom = repositoryHotelRoom;
       public HotelRoomDto GetHotelRoom(long id)
        {
            return _repositoryHotelRoom.Get(id);

        }
        public List<HotelRoomDto> GetHotelRooms()
        {
            return _repositoryHotelRoom.GetAll();
        }
       public void InsertHotelRoom(CreateHotelRoomDto dto)
        {
             _repositoryHotelRoom.Insert(dto);

        }
        public void UpdateHotelRoom(UpdateHotelRoomDto dto)
        {
            _repositoryHotelRoom.Update(dto);
        }
        public void DeleteHotelRoom(long id)
        {
            _repositoryHotelRoom.Delete(id);
        }

        public List<HotelRoomDto> GetAllHotelRooms(long id)
        {
            return _repositoryHotelRoom.GetAllHotelRooms(id);
        }
    }
}
