using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TokenBasedAuthenticationSample.Controllers
{
    
    public class TopSecretController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            return View((object)userName);
        }

        [Authorize(Roles ="Editor")]
        public ActionResult EditorsOnly()
        {
            var userName = User.Identity.Name;
            return View((object)userName);
        }
    }
}