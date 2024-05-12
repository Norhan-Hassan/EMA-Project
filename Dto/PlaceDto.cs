using System.ComponentModel.DataAnnotations;

namespace EMA_Project.Dto
{
    public class PlaceDto
    {
        [Required]
        public string PlaceName { get; set; }
        [Required]
        public string Category { get; set; }

    }
}