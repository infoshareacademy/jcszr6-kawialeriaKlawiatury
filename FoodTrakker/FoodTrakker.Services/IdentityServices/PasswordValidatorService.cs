using FoodTrakker.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FoodTrakker.Services.IdentityServices
{
    public class PasswordValidatorService : IPasswordValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
           if(password.Contains(user.UserName))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "Error with password",
                    Description = "Password can't be the same as user or contain user name!"                    
                }));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
