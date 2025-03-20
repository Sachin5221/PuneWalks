using System.ComponentModel.DataAnnotations;

namespace PuneWalksAPI.Models.DTO
{
    public class RegisterRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; } 
    }
}
