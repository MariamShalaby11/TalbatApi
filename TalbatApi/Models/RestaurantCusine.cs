using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TalbatApi.Models
{
    public class RestaurantCusine
    {
        [Key]
        [ForeignKey("Restaurant")]
        [Column(Order = 0)]
        public int RestaurantId { get; set; }

        [Key]
        [ForeignKey("Cuisine")]
        [Column(Order = 1)]
        public int CuisineId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual Cuisine Cuisine { get; set; }

    }
}