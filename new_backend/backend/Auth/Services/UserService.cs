using Application.Common.Models.Auth;
using Application.Common.Services.Auth;
using Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationUserManager _userManager;
        public UserService(ApplicationUserManager userManager) 
        { 
            _userManager = userManager;
        }
        public async Task<User> GetUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return new User
            { 
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ContactNo = user.ContactNo
            };
        }
    }
}
