using System.ComponentModel.DataAnnotations;
using ServiceFramework;
using TimeLog.API.Utils;

namespace TimeLog.API.Models
{
    public class User : ErrorLog
    {
        public int Id { get; set; }
        //[Required]
        [StringLength(60,
            ErrorMessage = "{0} must be at least {2} characters and a maximum of {1} characters in length.",
            MinimumLength = 4)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Only alphabetic characters allowed for {0}.")]
        [Display(Name = "First Name")]
        public string FullName { get; set; }

        //[Required]
        [RegularExpression(
            "^[a-zA-Z0-9_\\+-]+(\\.[a-zA-Z0-9_\\+-]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9]+)*\\.([a-zA-Z]{2,4})$",
            ErrorMessage = "Invalid {0}")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        //[Required]
        // [StringLength(3, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        public int SupervisorId { get; set; }
        [Required]
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}