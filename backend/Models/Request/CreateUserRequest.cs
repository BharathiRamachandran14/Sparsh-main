using System.ComponentModel.DataAnnotations;
using Sparsh.Models.Database;

namespace Sparsh.Models.Request
{
    public class CreateUserRequest
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
        [RegularExpression(
            @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"
        )]
        public string Password { get; set; }
        
        [Required]
        [RegularExpression(
            // Microsoft's recommended email address validation Regex (absolutely disgusting, I know)
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))"
            + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"
        )]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$")]
        public string  PhoneNumber{ get; set; }

        [Required]
        [StringLength(200)]
        public string  Address{ get; set; }


    }
}
