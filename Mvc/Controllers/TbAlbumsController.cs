using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class TbAlbumsController : Controller
    {
        // GET: TbAlbums
        public ActionResult Index()
        {
            IEnumerable<MVCTbAlbumsModel> List;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TrackTs").Result;
            List = response.Content.ReadAsAsync<IEnumerable<MVCTbAlbumsModel>>().Result;
            return View(List);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new MVCTbAlbumsModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TbUsers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCTbAlbumsModel>().Result);

            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MVCTbAlbumsModel user)
        {
            if (user.id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("TbUsers", user).Result;
                TempData["SuccessMessage"] = "Registrado con éxito";

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("TbUsers/" + user.id, user).Result;
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