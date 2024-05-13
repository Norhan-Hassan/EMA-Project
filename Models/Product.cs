using System.ComponentModel.DataAnnotations.Schema;

namespace EMA_Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public virtual ICollection<PlaceProduct> PlaceProducts { get; set; }


    }
}