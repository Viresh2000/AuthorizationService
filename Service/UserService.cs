using AuthorizationService.Models;
using AuthorizationService.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationService.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthorizationService.Service;

namespace AuthorizationService.Service
{
   public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        { 
            _userRepo = userRepo;
        }
        public List<LoginTbl> getuser()
        {
            return _userRepo.getuser();
        }

        public Boolean IsUserValid(LoginTbl user){
            return _userRepo.IsUservalid(user);
        }
    }
}
