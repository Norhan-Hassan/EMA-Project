using EMA_Project.Dto;
using EMA_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace EMA_Project.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPlaceService _placeService;
        public ProductService(ApplicationDbContext context, IPlaceService placeService)
        {
            _context = context;
            _placeService = placeService;
        }
        public int GetPlaceIdByName(string placeName)
        {
            var place = _context.Place
                .FirstOrDefault(p => p.PlaceName == placeName);

            return place?.Id ?? -1; 
        }
        public int GetProductIdByName(string productName)
        {
            var product = _context.Product
                .FirstOrDefault(p => p.ProductName == productName);

            return product?.Id ?? -1; // Return -1 if product is not found
        }
        public List<ProductDto> GetProductsForPlace(string placeName)
        {
            int placeId = GetPlaceIdByName(placeName);
            if (placeId != -1)
            {
                var place = _context.Place
                    .Include(p => p.PlaceProducts)
                    .ThenInclude(pp => pp.Product)
                    .FirstOrDefault(p => p.Id == placeId);

                var products = place.PlaceProducts.Select(pp => pp.Product)
                    .Select(p => new ProductDto
                    {
                        ProductImage = _placeService.GetMediaUrl(p.ProductImage),
                        ProductName = p.ProductName
                    })
                    .ToList();
                return products;
            }
            else
            {
                return null;
            }
        }
        public List<PlaceDto> GetPlacesByProduct(string productName)
        {
            int productId = GetProductIdByName(productName);
            if (productId != -1)
            {
                var places = _context.Place
                    .Include(p => p.PlaceProducts)
                    .ThenInclude(pp => pp.Product)
                    .Where(p => p.PlaceProducts.Any(pp => pp.Product.ProductName.Contains(productName)))
                    .Select(p => new PlaceDto
                    {
                        PlaceImage = _placeService.GetMediaUrl(p.PlaceImage),
                        PlaceName = p.PlaceName,
                        Category= p.category,
                        latitude=p.latitude,
                        longitude=p.longitude,
                    })
                    .ToList();

                return places;
            }
            return null;
        }
    }
}
