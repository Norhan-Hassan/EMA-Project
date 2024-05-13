using EMA_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace EMA_Project.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
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
        public List<Product> GetProductsForPlace(string placeName)
        {
            int placeId = GetPlaceIdByName(placeName);
            if(placeId != -1) {

                var place = _context.Place
                .Include(p => p.PlaceProducts)
                .ThenInclude(pp => pp.Product)
                .FirstOrDefault(p => p.Id == placeId);

                var products = place.PlaceProducts.Select(pp => pp.Product).ToList();
                return products;
            }
            else
            {
                return null;
            }
        }
        public List<Place> GetPlacesByProduct(string productName)
        {
            int placeId= GetProductIdByName(productName);
            if(placeId != -1 )
            {
                var places = _context.Place
                .Include(p => p.PlaceProducts)
                .ThenInclude(pp => pp.Product)
                .Where(p => p.PlaceProducts.Any(pp => pp.Product.ProductName.Contains(productName)))
                .ToList();

                return places;
            }
            return null;
        }
    }
}
