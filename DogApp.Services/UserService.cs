using Microsoft.AspNetCore.Identity;
using DogApp.Shared.EntityUserModels;
using System.Threading.Tasks;
using DogApp.Services.Interfaces;

namespace DogApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<SignInResult> LoginAsync(string userName, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(userName, password, rememberMe, lockoutOnFailure: false);
        }

        public Task LoginAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        // Andre metoder som f.eks. opdatering, sletning osv. kan tilføjes efter behov
    }
}
