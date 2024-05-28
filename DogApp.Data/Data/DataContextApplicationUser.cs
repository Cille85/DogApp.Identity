using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DogApp.Shared.EntityUserModels;



namespace DogApp.Data
{
    // DbContext for den anden database
    public class DataContextApplicationUser : IdentityDbContext<User>
    {
        public DataContextApplicationUser(DbContextOptions<DataContextApplicationUser> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        // DbSet for brugeren
        public DbSet<User> User { get; set; }

        
    }
}

