﻿using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Models.UserModels;
using Airport_App_Structure.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace Airport_App_Core.Services
{
    public class UserService : IUserService

    {
        private readonly AirportDb data;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(
            AirportDb _data,
            SignInManager<User> _signInmanager,
            RoleManager<IdentityRole> _roleManager,
            UserManager<User> _userManager
            )
        {
            data = _data;
            signInManager = _signInmanager;
            roleManager = _roleManager;
            userManager = _userManager;
        }

        public async Task AddUserToRole(User user)
        {
            var findUser = data.Users.First(x => x.UserName == user.UserName);
            if (findUser.UserName == "kostadin")
            {
                await userManager.AddToRoleAsync(findUser, "Admin");
            }

            else
            {
                await userManager.AddToRoleAsync(findUser, "User");
            }

            await data.SaveChangesAsync();
        }

        public async Task ChangePass(ChangePasswordModel model)
        {
            User user = data.Users
                .First(x => x.Id == model.UserId);


            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(model.NewPassword, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            user.PasswordHash = savedPasswordHash;

            await data.SaveChangesAsync();

        }

        public async Task<bool> LogInAsync(LogInViewModel model)
        {
            var findUser = data.Users.FirstOrDefault(x => x.UserName == model.Username);
            if (findUser== null)
            {
                return false;
            }
            string savedPasswordHash = findUser.PasswordHash;

            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(model.Password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }

            }

            await signInManager.SignInAsync(findUser, isPersistent: false);
            return true;

        }

        public async Task<User> RegisterNewUser(AddNewUserModel model)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(model.Password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            User user = new User()
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.Lastname,
                PasswordHash = savedPasswordHash,
            };


            data.Add(user);
            await data.SaveChangesAsync();
            await signInManager.SignInAsync(user, isPersistent: false);
            return user;
           
        }
    }
}
