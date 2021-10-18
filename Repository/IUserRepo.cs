using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.Repo
{
    public interface IUserRepo
    {
        public Boolean IsUservalid(LoginTbl user);
        public List<LoginTbl> getuser();
       
    }
}