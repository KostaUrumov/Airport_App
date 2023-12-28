using Aiport_App_Structure.Models;
using Airport_App_Core.Models.UserModels;

namespace Airport_App_Core.Contracts
{
    public interface IUserService
    {
        Task<User> RegisterNewUser(AddNewUserModel model);
        Task<bool> LogInAsync (LogInViewModel model);
        Task AddUserToRole(User user);
    }
}
