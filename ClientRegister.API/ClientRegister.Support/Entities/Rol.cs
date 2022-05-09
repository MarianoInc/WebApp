using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientRegister.Support.Entities
{
    public class Rol : EntityBase
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [StringLength(255)]
        public string? Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
