using DTO.CityDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceCity;


namespace WebHotel.Controllers;

[ApiController]
[Route ("city")]

public class CityController(ICityService cityService) : Controller
{
    [HttpGet]
    public JsonResult GetСitis()
    {
        var cities = cityService.GetCities();
        return Json(cities);
    }
    [Route ("{id}")]
    [HttpGet]
    public JsonResult GetCity(long id)
    { var city = cityService.GetCity(id);
    return Json(city);
    }
    [Authorize]
    [Route ("created")]
    [HttpPost]
    public JsonResult CreateCity(CreateCityDto dto )
    {
        cityService.InsertCity(dto);
        return Json(dto);
    }
    [Authorize]
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateCity(UpdateCityDto dto)
    {
        cityService.UpdateCity(dto);

        return Json("updated");
    }
    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteCity(long id)
    {
        cityService.DeleteCity(id);

        return Json("deleted");
    }
}
