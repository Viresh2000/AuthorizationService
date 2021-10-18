using AuthorizationService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthorizationService.Repo;
using AuthorizationService.Service;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationService.Repo
{
    public class UserRepo : IUserRepo
    {
        private AuthContext context;

        public UserRepo(AuthContext authContext)
        {
            context = authContext;

        }
        public List<LoginTbl> getuser()  
        {
            List<LoginTbl> users = context.LoginTbls.ToList();
            return users;
        }

        public Boolean IsUservalid(LoginTbl user)
        {
            List<LoginTbl> users = getuser();
            foreach (LoginTbl u in users)
            {
                if (user.Username == u.Username && user.Pass == u.Pass)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
