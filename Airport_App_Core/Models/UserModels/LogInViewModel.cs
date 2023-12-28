using Aiport_App_Structure.Data;
using System.ComponentModel.DataAnnotations;

namespace Airport_App_Core.Models.UserModels
{
    public class LogInViewModel
    {
        [Required]
        [StringLength(DataConstraints.User.MaxUserName, MinimumLength = DataConstraints.User.MinUserName)]
        public string Username { get; set; } = null!;


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
