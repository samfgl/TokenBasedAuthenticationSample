using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TokenBasedAuthenticationSample.Controllers
{
    [Authorize]
    public class TopSecretController : Controller
    {
        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            return View((object)userName);
        }
    }
}