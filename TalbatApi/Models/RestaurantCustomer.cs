using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TalbatApi.Models
{
    public class RestaurantCustomer
    {
        [Key]
        [ForeignKey("Restaurant")]
        [Column(Order = 0)]
        public int RestaurantId { get; set; }

        [Key]
        [ForeignKey("Customer")]
        [Column(Order = 1)]
        public int CustomerId { get; set; }


        public int Rate { get; set; }

        public string Comment { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual Customer Customer { get; set; }

    }
}