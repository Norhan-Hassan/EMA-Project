using System.ComponentModel.DataAnnotations.Schema;

namespace EMA_Project.Models
{
    public class PlaceProduct
    {
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Place Place { get; set; }
        public virtual Product Product { get; set; }




    }
}