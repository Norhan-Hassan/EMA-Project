using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMA_Project.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Gender { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\w+([\.-]?\w+)*@gmail\.com$", ErrorMessage = "Email format is invalid. It must be example@gmail.com")]
        public string Email { get; set; }

        [Range(1, 4, ErrorMessage = "level must be btween 1 and 4.")]
        public int Level { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }


    }
}