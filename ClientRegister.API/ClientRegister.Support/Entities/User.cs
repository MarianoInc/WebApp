using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientRegister.Support.Entities
{
    public class User : EntityBase
    {
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(65)]
        public string Password { get; set; }

        [Required]
        [ForeignKey("RolesId")]
        public int RolesId { get; set; }
        public Rol Roles { get; set; }
    }
}
