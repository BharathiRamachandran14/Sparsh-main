using System.ComponentModel.DataAnnotations;
using Sparsh.Models.Database;
using Sparsh.Models.Request;

namespace Sparsh.Models.Response
{
    public class UserResponse
    {
        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        [StringLength(70)]
        public string Username { get; set; }

        [Required]
        public Role Role { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(14)]
        public string  PhoneNumber{ get; set; }

        [Required]
        [StringLength(200)]
        public string  Address{ get; set; }

        public UserResponse(CreateUserRequest newUserRequest)
        {
            this.Name = newUserRequest.Name;
            this.Username = newUserRequest.Username;
            this.Role = newUserRequest.Role;
            this.Email = newUserRequest.Email;
            this.PhoneNumber = newUserRequest.PhoneNumber;
            this.Address = newUserRequest.Address;     
        }

        public UserResponse(User newUser)
        {
            this.Name = newUser.Name;
            this.Username = newUser.Username;
            this.Role = newUser.Role;
            this.Email = newUser.Email;
            this.PhoneNumber = newUser.PhoneNumber;
            this.Address = newUser.Address;        
        }
    }
}