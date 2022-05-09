using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClientRegister.Support.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [Required]
        public DateTime ModifiedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
