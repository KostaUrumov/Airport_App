using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Airport_App_Core.Models.UserModels
{
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string RepeatNewPassword { get; set; } = null!;

        public string? UserId { get; set; }
    }
}
