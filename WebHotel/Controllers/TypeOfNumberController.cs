using DTO.TypeOfNumberDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceTypeOfNumber;

namespace WebHotel.Controllers
{
    [ApiController]
    [Route("typeofnumber")]
    public class TypeOfNumberController(IServiceTypeOfNumber serviceTypeOfNumber) : Controller
    {
        [HttpGet]
        public JsonResult GetTypeOfNumber()
        {
            var type = serviceTypeOfNumber.GetTypeOfNumbers();
            return Json(type);
        }
        [Route("{id}")]
        [HttpGet]
        public JsonResult PostHotelRoom(long id)
        {
            var type = serviceTypeOfNumber.GetTypeOfNumber(id);
            return Json(type);
        }
        [Authorize]
        [Route("create")]
        [HttpPost]
        public JsonResult CreateTypeOfNumber(CreateTypeOfNumberDto dto)
        {
            serviceTypeOfNumber.InsertTypeOfNumber(dto);
            return Json("created");
        }
        [Authorize]
        [Route("update")]
        [HttpPatch]
        public JsonResult UpdateTypeOfNumber(UpdateTypeOfNumberDto dto)
        {
           serviceTypeOfNumber.UpdateTypeOfNumber(dto);

            return Json("updated");
        }
        [Authorize]
        [Route("delete/{id}")]
        [HttpDelete]
        public JsonResult DeleteTypeOfNumber(long id)
        {
            serviceTypeOfNumber.DeleteTypeOfNumber(id);

            return Json("deleted");
        }
    }
}
