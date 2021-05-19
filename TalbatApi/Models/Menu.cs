using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TalbatApi.Models
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuID { get; set; }
        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}