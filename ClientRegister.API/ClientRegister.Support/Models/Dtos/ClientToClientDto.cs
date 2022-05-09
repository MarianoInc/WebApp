using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClientRegister.Support.Models.Dtos
{
    public class ClientToClientDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(255, ErrorMessage = "Maximum of characters allowed: 255")]
        public string FullName { get; set; }

        //National Identifier Document.
        [Required(ErrorMessage = "National identifier document field is required")]
        [RegularExpression(@"^([0-9]{8})$", ErrorMessage = "Invalid DNI Number.")]
        public int DNI { get; set; }

        [Required(ErrorMessage = "Age field is required")]
        [Range(0, 130, ErrorMessage = "Age must be between 0 - 130")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender field is required")]
        public string Gender { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "You must especifie if the client Drives")]
        public bool DriverLicense { get; set; }

        [Required(ErrorMessage = "You must especifie if the client use glasses")]
        public bool UseGlasses { get; set; }

        [Required(ErrorMessage = "You must especifie if the client has diabetes")]
        public bool IsDiabetic { get; set; }

        [Required(ErrorMessage = "You must especifie if the client has other disease")]
        public bool OtherDisease { get; set; }

        [StringLength(255, ErrorMessage = "Maximum of characters allowed: 255")]
        public string Disease { get; set; }

        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
}
