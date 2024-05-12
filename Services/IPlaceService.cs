using EMA_Project.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EMA_Project.Services
{
    public interface IPlaceService
    {
        public List<GetALLPlacesDto> GetAllPlaces();
    }
}