using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class RegUserController : Controller
    {
        // GET: RegUser
        public ActionResult AddOrEdit(int id = 0)
        {
            RegUserModel regumodel = new RegUserModel();

            return View(regumodel);
        }

        //[HttpPost]
        //public ActionResult AddOrEdit(RegUserModel regumodel)
        //{
        //    using ()
        //}
    }
}