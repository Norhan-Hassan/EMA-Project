
using System.ComponentModel.DataAnnotations;

namespace EMA_Project.Dto
{
    public class ProductDto
    {
        [Required]
        public string ProductName  { get; set; }
        [Required]
        public string ProductImage { get; set; }

    }
}
