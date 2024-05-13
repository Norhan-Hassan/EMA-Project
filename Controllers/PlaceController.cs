using EMA_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMA_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _PlaceService;

        public PlaceController(IPlaceService PlaceService)
        {
            _PlaceService = PlaceService;

        }
       [HttpGet("getAllPlaces")]
       public IActionResult GetAllplaces()
        {
            var Places = _PlaceService.GetAllPlaces();
            return Ok(Places);
        }
        //[HttpGet("PlaceProducts")]
        //public IActionResult GetPlaceProducts(string PlaceName, string Categry)
        //{
        //    var PlaceProducts = _PlaceService.GetPlaceProducts(PlaceName, Categry);
        //    return Ok(PlaceProducts);
        //}

    }
}