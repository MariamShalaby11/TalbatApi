using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TalbatApi.Models;

namespace TalbatApi.Controllers
{
    public class FilterController : ApiController
    {
        Talabat db = new Talabat();
        // GET api/values


        [Route("api/values/tab1")]
        public IEnumerable<Restaurant> Gettab1()
        {
            return db.Restaurants;
        }
        [Route("api/values/tab4")]
        public List<Restaurant> Gettab2()
        {
            List<RestaurantCustomer> rc = db.RestaurantCustomers.ToList();
            for(int i=0;i<rc.Count;i++)
            {
                for(int j=0;j<rc.Count;j++)
                {
                    if(i!=j)
                    {
                        if(rc[i].RestaurantId==rc[j].RestaurantId)
                        {
                            rc[i].Rate += rc[j].Rate;
                            rc.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
            return rc.OrderByDescending(a=>a.Rate).Select(a=>a.Restaurant).ToList(); 
        }
        [Route("api/values/tab3")]
        public IEnumerable<Restaurant> Gettab3()
        {
            return null;
        }
        [Route("api/values/tab2")]
        public IEnumerable<Restaurant> Gettab4()
        {
            
            
            return db.Restaurants.OrderBy(a=>a.RestaurantName);
        }



        public List<Restaurant> Get(string character)=>
            db.Restaurants.Where(a => a.RestaurantName.Contains(character)).Select(a => a).ToList();


        [Route("api/values/GetAllCusins")]
        public IEnumerable<Cuisine> GetAllCusins()=>db.Cuisines;


        [Route("api/values/Cusins")]

        public IEnumerable<Restaurant> GetAllCusinsFilter(string filter)
        {
            List<Restaurant>allres= db.RestaurantCusines.Where(a=>a.Cuisine.CuisineName== filter).Select(a=>a.Restaurant).ToList();
            return allres;
        }


        // POST api/values
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
