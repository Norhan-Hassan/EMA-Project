using EMA_Project.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EMA_Project.Services
{
    public interface IPlaceService
    {
         List<PlaceDto> GetAllPlaces();
         List<ProductDto> GetPlaceProducts(string placeName, string Category);
         string GetMediaUrl(string CityImage);


    }
}