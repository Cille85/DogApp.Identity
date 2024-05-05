using DogApp.Data;
using DogApp.Shared.EntityModels;
using DogApp.Shared.EntityUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DogApp.Repository.UserRepo
{
    public class UserRepo : GenericUserRepository, IUserRepository
    {
        public UserRepo(DataContextApplicationUser context) : base(context)
        {
        }
    }

}
