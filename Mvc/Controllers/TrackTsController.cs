using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class TrackTsController : Controller
    {
        // GET: TrackTs
        public ActionResult Index()
        {
            IEnumerable<MVCTrackTsModel> trList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TrackTs").Result;
            trList = response.Content.ReadAsAsync<IEnumerable<MVCTrackTsModel>>().Result;
            return View(trList);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new MVCTrackTsModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TbUsers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCTrackTsModel>().Result);

            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MVCTrackTsModel user)
        {
            if (user.album_id== 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("TbUsers", user).Result;
                TempData["SuccessMessage"] = "Registrado con éxito";

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("TbUsers/" + user.album_id, user).Result;
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