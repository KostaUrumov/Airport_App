using Airport_App_Core.Models.UserModels;

namespace Airport_App_Core.Contracts
{
    public interface IUserService
    {
        Task RegisterNewUser(AddNewUserModel model);
        Task<bool> LogInAsync (LogInViewModel model);
    }
}
