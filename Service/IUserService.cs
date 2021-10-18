using AuthorizationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Service
{
    interface IUserService
    {
        public List<LoginTbl> getuser();
        public Boolean IsUserValid(LoginTbl user);
    }
}
