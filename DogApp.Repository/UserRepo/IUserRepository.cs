using DogApp.Shared.EntityUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogApp.Repository.UserRepo
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        //Task<User?> GetUserByIdAsync(string userId);
        //Task<User?> GetUserByNameAsync(string userName);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
        //Task<User?> LoginAsync(string userName, string password);
    }
}
