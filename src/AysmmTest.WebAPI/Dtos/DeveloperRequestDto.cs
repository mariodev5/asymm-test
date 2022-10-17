using AysmmTest.WebAPI.Validators;
using System.ComponentModel.DataAnnotations;

namespace AysmmTest.WebAPI.Dtos
{
    public class DeveloperRequestDto
    {
        [Required]
        [FirstLetterCapitalized]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        public string Level { get; set; }
    }
}
