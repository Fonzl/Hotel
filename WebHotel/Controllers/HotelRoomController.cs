
using DTO.HotelRoomDto;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceHotelRoom;

namespace WebHotel.Controllers
{
    [ApiController]
    [Route("hotelroom")]
    public class HotelRoomController(IServiceHotelRoom serviceHotelRoom) : Controller
    {
        [HttpGet]
        public JsonResult GetHotelRooms()
        {
            var hotelrooms = serviceHotelRoom.GetHotelRooms();
            return Json(hotelrooms);
        }
        [Route("{id}")]
        [HttpGet]
        public JsonResult PostHotelRoom(long id)
        {
            var hotelroom = serviceHotelRoom.GetHotelRoom(id);
            return Json(hotelroom);
        }
        [Route("create")]
        [HttpPost]
        public JsonResult CreateHotelRoom(CreateHotelRoomDto dto)
        {
            serviceHotelRoom.InsertHotelRoom(dto);
            return Json("created");
        }
        [Route("update")]
        [HttpPatch]
        public JsonResult UpdateHotelRoom(UpdateHotelRoomDto dto)
        {
            serviceHotelRoom.UpdateHotelRoom(dto);

            return Json("updated");
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public JsonResult DeleteHotelRoom(long id)
        {
           serviceHotelRoom.DeleteHotelRoom(id);

            return Json("deleted");
        }
    }
}
