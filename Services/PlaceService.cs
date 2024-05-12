
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

        public List<GetALLPlacesDto> GetAllPlaces()
        {
            var places = _context.Place.ToList();
            List<GetALLPlacesDto> PlaceDtos = new List<GetALLPlacesDto>();


            foreach (var place in places)
            {
                GetALLPlacesDto placeDto = new GetALLPlacesDto
                {
                    PlaceName = place.PlaceName,
                    Category = place.category,

                };
                PlaceDtos.Add(placeDto);
            }
            return PlaceDtos;
        }
        //public List<> GetPlaceProducts( string placeName, string Category)
        //{

        //}
    }
}

