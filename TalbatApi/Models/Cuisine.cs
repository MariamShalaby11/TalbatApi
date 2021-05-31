using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TalbatApi.Models
{
    public class Cuisine
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CuisineID { get; set; }
        [Required]
        public string CuisineName { get; set; }

        public virtual List<RestaurantCusine> restaurantCusines { get; set; }
    }
}