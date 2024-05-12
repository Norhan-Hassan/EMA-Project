using System.ComponentModel.DataAnnotations;

namespace EMA_Project.Models
{
    public class Place
    {
        [Key]
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public string category { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public ICollection<PlaceProduct> PlaceProducts { get; set; }


    }
}