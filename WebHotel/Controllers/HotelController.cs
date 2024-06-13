
using DTO.CountryDto;
using DTO.HotelDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceHotel;
using Service.ServiceHotelRoom;

namespace WebHotel.Controllers
{
    [ApiController]
    [Route("hotel")]
    public class HotelController(IServiceHotel hotelService,IServiceHotelRoom serviceHotelRoom) : Controller
    {
        [HttpGet]
        public JsonResult GetHotels()
        {
            var hotels = hotelService.GetHotels();
            return Json(hotels);
        }
        [Route("{id}")]
        [HttpGet]
        public  JsonResult PostHotel(long id)
        {
            var hotel = hotelService.GetHotel(id);
           
            return Json(hotel);
            
        }
        [Authorize]
        [Route("create")]
        [HttpPost]
        public JsonResult CreateHotel(CreateHotelDto dto)
        {
            hotelService.InsertHotel(dto);
            return Json("created");
        }
        [Authorize]
        [Route("update")]
        [HttpPatch]
        public JsonResult UpdateHotel(UpdateHotelDto dto)
        {
            hotelService.UpdateHotel(dto);

            return Json("updated");
        }
        [Authorize]
        [Route("delete/{id}")]
        [HttpDelete]
        public JsonResult DeleteHotel(long id)
        {
            hotelService.DeleteHotel(id);

            return Json("deleted");
        }
    }
}
