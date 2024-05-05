using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogApp.Data
{
    internal class UserConfiguration : IEntityTypeConfiguration<object>
    {
        public void Configure(EntityTypeBuilder<object> builder)
        {
            throw new NotImplementedException();
        }
    }
}