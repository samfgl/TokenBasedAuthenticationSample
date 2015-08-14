using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenBasedAuthenticationSample.Models
{
    public class AppUser : IUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }
    }
}