using EMA_Project.Models;

namespace EMA_Project.Services
{
    public interface IProductService
    {
        int GetPlaceIdByName(string placeName);
        List<Product> GetProductsForPlace(string placeName);
        List<Place> GetPlacesByProduct(string productName);
    }
}
