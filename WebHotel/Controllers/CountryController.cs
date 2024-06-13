using DTO.CountryDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceCountry;

namespace WebHotel.Controllers;

[ApiController]
[Route ("countries")]

public class CountryController(ICountryService countryService) : Controller
{
    [HttpGet]
    public JsonResult GetCountries()
    {
        var countrs = countryService.GetCountries();
        return Json(countrs);
    }
    [Route ("{id}")]
    [HttpGet]
    public JsonResult GetCountry(long id)
    { var country = countryService.GetCountry(id);
    return Json(country);
    }
    [Authorize]
    [Route ("created")]
    [HttpPost]
    public JsonResult CreateCountry(CreateCountryDto dto )
    {
        countryService.InsertCountry(dto);
        return Json(dto);
    }
    [Authorize]
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateCountry(UpdateCountryDto dto)
    {
        countryService.UpdateCountry(dto);

        return Json("updated");
    }
    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteCountry(long id)
    {
        countryService.DeleteCountry(id);

        return Json("deleted");
    }
}
