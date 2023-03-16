using BookanLibrary.Core.Model.Enums;
using BookanLibrary.Core.Model;

namespace BookanAPI.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
        public Address Address { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
