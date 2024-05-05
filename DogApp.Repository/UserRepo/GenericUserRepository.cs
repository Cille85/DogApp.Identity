using DogApp.Data;
using Microsoft.EntityFrameworkCore;
using DogApp.Shared.EntityUserModels;
using Microsoft.AspNetCore.Identity;

namespace DogApp.Repository.UserRepo
{
    public class GenericUserRepository
    {
        private readonly DataContextApplicationUser _context;

        public GenericUserRepository(DataContextApplicationUser context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }



        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<IdentityUser?> GetUserByIdAsync(string userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<IdentityUser?> GetUserByNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<IdentityUser?> LoginAsync(string userName, string password)
        {
            // Retrieve user from database by username
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user != null && await VerifyPasswordAsync(user, password))
            {
                return user;
            }

            return null;
        }

        private async Task<bool> VerifyPasswordAsync(IdentityUser user, string password)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> VerifyPasswordAsync(User user, string password)
        {
            // Implement password verification logic here
            // Example: return await _userManager.CheckPasswordAsync(user, password);
            return true; // Replace this with your actual logic
        }


    }
}
