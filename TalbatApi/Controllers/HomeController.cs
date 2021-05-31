using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TalbatApi.Models;
namespace TalbatApi.Controllers
{
    public class HomeController : Controller
    {
        private Talabat db = new Talabat();
        [HttpGet]

        public ActionResult RestrauntAddresses()
        {
            var restaurants = db.Restaurants.Include(r => r.Address).Select(c => c.Address.city).Distinct();

            return Json(restaurants, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult TopRatedRestaunt(string _city)
        {
            if (_city == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int restaurant_id = db.Restaurants.Include(r => r.Address).Where(a => a.Address.city == _city).Select(res => res.RestaurantId).First();
            if (restaurant_id == 0)
            {
                return HttpNotFound();
            }
            var restaurants = db.RestaurantCustomers.Where(c => c.RestaurantId == restaurant_id).OrderBy(r => r.Rate).Take(5);
            return Json(restaurants, JsonRequestBehavior.AllowGet);
        }



    }
}
