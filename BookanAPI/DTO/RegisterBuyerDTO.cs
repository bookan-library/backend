using BookanLibrary.Core.Model.Enums;
using BookanLibrary.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace BookanAPI.DTO
{
    public class RegisterBuyerDTO
    {
        [Required(ErrorMessage = "Required!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Required!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Required!")]
        public Address Address { get; set; }
    }
}
