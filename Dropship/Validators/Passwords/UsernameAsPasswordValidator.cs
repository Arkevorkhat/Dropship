using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dropship.Validators.Passwords
{
    public class UsernameAsPasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : IdentityUser
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            if (string.Equals(user.UserName, password, StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError { Code = "UNAsPW", Description = "You may not use your username as your password. Please select a different password." }));
            }
            else return Task.FromResult(IdentityResult.Success);
        }
    }
}
