using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TalbatApi.Models;

namespace TalbatApi.Controllers
{
    public class RestaurantController : ApiController
    {
        Talabat db = new Talabat();

        //get all restaurants
        [Route("api/AllRestPage")]
        public IHttpActionResult getAllRestaurants()
        {
            //int rest_id = db.Restaurants.Select(r=>r.RestaurantId).FirstOrDefault();
            //List<Restaurant> AllRestaurants = db.RestaurantCustomers.Where(b => b.RestaurantId == rest_id).OrderBy(a => a.Rate).ToList();

            //List<Restaurant> AllRestaurants = db.RestaurantCustomers.OrderBy(a => a.Rate).Select(a => a.Restaurant).ToList();

            List<Restaurant> AllRestaurants = db.Restaurants.OrderBy(a => a.RestaurantName).ToList();

            if (AllRestaurants == null)
                return NotFound();
            else
                return Ok(AllRestaurants);
        }

        //Search for restaurant
        [Route("api/search/{ch}")]
        [HttpGet]
        public IHttpActionResult SearchRest(string ch)
        {
            List<Restaurant> AllRestaurants = db.Restaurants.Where(a => a.RestaurantName.Contains(ch)).Select(a => a).ToList();
            if (AllRestaurants == null)
                return NotFound();
            else
                return Ok(AllRestaurants);
        }

        //get restaurant page by id
        [Route("api/Rest/{id}")]
        public IHttpActionResult getRestById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Restaurant Rest = db.Restaurants.Find(id);

            if (Rest == null)
                return NotFound();
            else
                return Ok(Rest);
        }

        // get restaurant reviews and rates
        [Route("api/rate/{id}")]
        [HttpGet]
        public IHttpActionResult ReviewDetails(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            List<RestaurantCustomer> RestCust = db.RestaurantCustomers.Where(a => a.RestaurantId == id).ToList();
            if (RestCust == null)
                return NotFound();
            else
                return Ok(RestCust);
        }

        //get restaurants have offers only
        [Route("api/RestOffers")]
        [HttpGet]
        public IHttpActionResult RestOffers()
        {
            var RestaurantsWithOffers = (from M in db.Meals.Where(r => r.Discount != 0)
                                         join C in db.Categories on M.CategoryId equals C.CategoryId
                                         join Me in db.Menus on C.MenuID equals Me.MenuID
                                         join R in db.Restaurants on Me.RestaurantID equals R.RestaurantId
                                         select R).ToList();
            if (RestaurantsWithOffers == null)
                return NotFound();
            else
                return Ok(RestaurantsWithOffers);

        }

        //get meals have discount only
        [Route("api/MealOffers/{id}")]
        [HttpGet]
        public IHttpActionResult MealOffers(int id)
        {
            // List<Meal> meals = db.Meals.Where(r => r.Discount != 0).ToList();

            var RestaurantsWithMeals = (from M in db.Meals.Where(r => r.Discount != 0)
                                        join C in db.Categories on M.CategoryId equals C.CategoryId
                                        join Me in db.Menus on C.MenuID equals Me.MenuID
                                        join R in db.Restaurants on Me.RestaurantID equals R.RestaurantId
                                        select R).Where(R => R.RestaurantId == id).ToList();


            // Restaurant rest = RestaurantsWithMeals.Where(a => a.RestaurantId == id).FirstOrDefault();

            List<Meal> mealOffer = (from m in db.Meals
                                    join C in db.Categories on m.CategoryId equals C.CategoryId
                                    join Me in db.Menus on C.MenuID equals Me.MenuID
                                    join R in RestaurantsWithMeals on Me.RestaurantID equals R.RestaurantId
                                    select m).ToList();

            if (mealOffer == null)
                return NotFound();
            else
                return Ok(mealOffer);
        }
    }
}
