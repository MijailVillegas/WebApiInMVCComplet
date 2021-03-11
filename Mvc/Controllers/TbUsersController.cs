using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class TbUsersController : Controller
    {
        // GET: TbUsers
        public ActionResult Index()
        {
            IEnumerable<MVCTbuserModel> userList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TbUsers").Result;
            userList = response.Content.ReadAsAsync<IEnumerable<MVCTbuserModel>>().Result;
            return View(userList);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id==0)
            {
                return View(new MVCTbuserModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TbUsers/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCTbuserModel>().Result);

            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MVCTbuserModel user)
        {
            if (user.usr_id==0)
            {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("TbUsers", user).Result;
            TempData["SuccessMessage"] = "Registrado con éxito";

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("TbUsers/"+user.usr_id, user).Result;
                TempData["SuccessMessage"] = "Corregido con éxito";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("TbUsers/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Eliminado con éxito";
            return RedirectToAction("Index");
        }
    }
}