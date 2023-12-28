using Aiport_App_Structure.Data;
using System.ComponentModel.DataAnnotations;

namespace Airport_App_Core.Models.UserModels
{
    public class AddNewUserModel
    {
        [Required]
        [StringLength(DataConstraints.User.MaxUserName, MinimumLength = DataConstraints.User.MinUserName)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(DataConstraints.User.MaxNameLenght, MinimumLength = DataConstraints.User.MinNameLenght)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(DataConstraints.User.MaxNameLenght, MinimumLength = DataConstraints.User.MinNameLenght)]
        public string Lastname { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; } = null!;
    }
}
