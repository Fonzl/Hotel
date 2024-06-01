
using DTO.HotelСhainDto;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceHotelChain;

namespace WebHotel.Controllers
{
    [ApiController]
    [Route("hotelchain")]
    public class HotelChainController(IServiceHotelChain serviceHotelChain) : Controller
    {
        [HttpGet]
        public JsonResult GetHotelChains()
        {
            var hotelchains = serviceHotelChain.GetHotelChains();
            return Json(hotelchains);
        }
        [Route("{id}")]
        [HttpGet]
        public JsonResult PostHotelChain(long id)
        {
            var hotelchain = serviceHotelChain.GetHotelChain(id);
            return Json(hotelchain);
        }
        [Route("create")]
        [HttpPost]
        public JsonResult CreateHotelChain(CreateHotelChainDto dto)
        {
            serviceHotelChain.InsertHotelChain(dto);
            return Json("created");
        }
        [Route("update")]
        [HttpPatch]
        public JsonResult UpdateHotelChain(UpdateHotelChainDto dto)
        {
            serviceHotelChain.UpdateHotelChainm(dto);

            return Json("updated");
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public JsonResult DeleteHotelChain(long id)
        {
            serviceHotelChain.DeleteHotelChain(id);

            return Json("deleted");
        }
    }
}
