using System.ComponentModel.DataAnnotations;

namespace ClientRegister.Support.Models.Dtos
{
    public class AuthUserDto
    {
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(65)]
        public string Password { get; set; }
    }
}
