using System;
using System.Collections.Generic;

#nullable disable

namespace AuthorizationService.Models
{
    public partial class LoginTbl
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
    }
}
