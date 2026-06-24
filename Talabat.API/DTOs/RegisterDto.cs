using System.ComponentModel.DataAnnotations;

namespace Talabat.API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string Country { get; set; }
        [Required]

        public string Street { get; set; }
        [Required]

        public string ZipCode { get; set; }
    }
}
