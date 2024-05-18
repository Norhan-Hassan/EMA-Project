using EMA_Project.Dto;
using EMA_Project.Models;

namespace EMA_Project.Services
{
    public interface IProductService
    {
        int GetPlaceIdByName(string placeName);
        List<ProductDto> GetProductsForPlace(string placeName);
        List<PlaceDto> GetPlacesByProduct(string productName);
        List<string> GetAllProducts();
    }
}
