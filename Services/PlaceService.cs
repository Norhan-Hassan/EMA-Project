
using EMA_Project.Dto;
using EMA_Project.Models;
using EMA_Project.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace EMA_Project.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        public PlaceService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<PlaceDto> GetAllPlaces()
        {
            var places = _context.Place.ToList();
            List<PlaceDto> PlaceDtos = new List<PlaceDto>();


            foreach (var place in places)
            {
                PlaceDto placeDto = new PlaceDto
                {
                    PlaceName = place.PlaceName,
                    Category = place.category,
                    PlaceImage = GetMediaUrl(place.PlaceImage)
                };
                PlaceDtos.Add(placeDto);
            }
            return PlaceDtos;
        }
        

        public List<ProductDto> GetPlaceProducts(string placeName, string Category)
        {
           
                var placeProducts = _context.Place
                    .Where(p => p.PlaceName == placeName && p.category == Category)
                    .SelectMany(p => p.PlaceProducts)
                    .Select(pp => new ProductDto
                    {
                        
                        ProductName = pp.Product.ProductName,
                        ProductImage = GetMediaUrl(pp.Product.ProductImage)
                    })
                    .ToList();

                return placeProducts;
            

        }
        public string GetMediaUrl(string CityImage)
        {

            var request = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            return $"{baseUrl}/{CityImage}";
        }
    }
}

