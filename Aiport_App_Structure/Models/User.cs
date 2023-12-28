using Aiport_App_Structure.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Aiport_App_Structure.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(DataConstraints.User.MinNameLenght)]
        [MaxLength(DataConstraints.User.MaxNameLenght)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(DataConstraints.User.MinNameLenght)]
        [MaxLength(DataConstraints.User.MaxNameLenght)]
        public string LastName { get; set; } = null!;
    }
}
