using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TalbatApi.Models;

using TalbatApi.ApiModels;

namespace TalbatApi.Controllers
{
    public class BecomePartnerController : Controller
    {
        // GET: BecomePartner
        private Talabat tb = new Talabat();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult PartnerRegistration(PartnerRegister data)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Address restrauntAddress = new Address();

            if (data.FullAddress == null)
            {
                return new HttpStatusCodeResult(400);
            }

            else
            {
                string[] _fulladdress = data.FullAddress.Split(',');


                if (_fulladdress.Length >= 3 && _fulladdress[0].ToLower() != _fulladdress[1].ToLower())
                {
                    restrauntAddress.city = _fulladdress[1];
                    restrauntAddress.Street = _fulladdress[0];
                }
                else
                {
                    restrauntAddress.city = _fulladdress[1];
                }
                restrauntAddress.lat = data.latitude; //data.latitude;
                restrauntAddress.lang = data.longtude; ;// data.longtude;
                tb.Addresses.Add(restrauntAddress);
            }
            tb.SaveChanges();
            Partener partner = new Partener()
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Approval = 0,
                CPassword = "123",
                Email = data.Email,
                Username = "mm88",
                Password = "123"

            };

            Restaurant restarunt = new Restaurant()
            {
                AddressID = restrauntAddress.AddressId,
                Address = restrauntAddress,
                PartenerID = partner.PartenerId,
                WebSite = data.WebSite,
                RestaurantName = data.RestaurantName,
                Description = "byby",
                EndWorkingHours = 2,
                Partener = partner,
                HotLine = "123",
                MaxDeliveryTime = 12,
                StartWorkingHours = 4
            };
            tb.Parteners.Add(partner);
            tb.SaveChanges();
            tb.Restaurants.Add(restarunt);
            tb.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);



        }
    }
}