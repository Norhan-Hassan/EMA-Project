using EMA_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMA_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{placeName}/products")]
        public IActionResult GetProductsForPlace(string placeName)
        {
            var products = _productService.GetProductsForPlace(placeName);

            if (products == null)
            {
                return NotFound("Place not found");
            }

            return Ok(products);
        }
        [HttpGet("{productName}/searchByProduct")]
        public IActionResult GetPlacesByProduct(string productName)
        {
            var places = _productService.GetPlacesByProduct(productName);

            if (places == null || places.Count == 0)
            {
                return NotFound("No places found for the specified product");
            }

            return Ok(places);
        }
        [HttpGet("/GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            if (products.Count > 0)
            {
                return Ok(products);
            }
            else
            { return BadRequest("No Products are Found"); }
        }

    }
}

