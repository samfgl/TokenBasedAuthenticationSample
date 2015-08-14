using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace TokenBasedAuthenticationSample.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string token)
        {
            var ident = new ClaimsIdentity(
            new[]
            {
                // since userCer is unique for each user we could easily
                // use it as a claim. If not use user table ID 
                new Claim(ClaimTypes.NameIdentifier,token),
                new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                new Claim(ClaimTypes.Name,token+"Name"),

                new Claim("Certificate", token),
                // populate assigned user's role form your DB 
                // and add each one as a claim  
                new Claim(ClaimTypes.Role,"R1"),
                new Claim(ClaimTypes.Role,"R2"),
                // and so on
            },
            DefaultAuthenticationTypes.ApplicationCookie);

            //Identity is sign in user based on claim don't matter 
            // how you generated it Identity take care of it
            HttpContext.GetOwinContext().Authentication.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);

            //// auth is succeed, without needing any password just claim based 
            return RedirectToAction("Index", "TopSecret");
        }
    }
}