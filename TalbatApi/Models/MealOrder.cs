using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TalbatApi.Models
{
    public class MealOrder
    {

        [Key]
        [ForeignKey("Meal")]
        [Column(Order = 0)]
        public int MealId { get; set; }

        [Key]
        [ForeignKey("Order")]
        [Column(Order = 1)]
        public int OrderId { get; set; }


        public int Quantity { get; set; }

        public virtual Meal Meal { get; set; }

        public virtual Order Order { get; set; }



    }
}