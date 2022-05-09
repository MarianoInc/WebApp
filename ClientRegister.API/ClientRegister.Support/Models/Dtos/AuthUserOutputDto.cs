using System.ComponentModel.DataAnnotations;

namespace ClientRegister.Support.Models.Dtos
{
    public class AuthUserOutputDto
    {
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }
        
        [Required]
        public string Token { get; set; }
    }
}
