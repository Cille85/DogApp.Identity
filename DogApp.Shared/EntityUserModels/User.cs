using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogApp.Shared.EntityUserModels
{
   public class User : IdentityUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
