using InitDemo.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitDemo.Models;
using InitDemo.Data;

namespace InitDemo.Services
{
    public class UsersService :BaseService<ApplicationUser>, IUsersService
    {
        public UsersService(IBlogSystemData data)
            :base(data)
        {
        }

    }
}
