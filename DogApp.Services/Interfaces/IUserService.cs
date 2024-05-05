using DogApp.Shared.EntityUserModels;
using Microsoft.AspNetCore.Identity;

namespace DogApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<User> GetUserByIdAsync(string userId);
        Task<User> GetUserByNameAsync(string userName);
        Task<SignInResult> LoginAsync(string userName, string password, bool rememberMe);
        Task LoginAsync(string userName, string password);
        Task LogoutAsync();
    }
}