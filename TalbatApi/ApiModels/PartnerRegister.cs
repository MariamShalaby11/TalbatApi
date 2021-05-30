using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TalbatApi.ApiModels
{
    public class PartnerRegister
    {
        [Required]
        [RegularExpression("^[a-zA-Z]{3,9}$")]

        public string FirstName { set; get; }
        [Required]
        [RegularExpression("^[a-zA-Z]{3,9}$")]

        public string LastName { set; get; }

        [Required]
        [DisplayName("Name")]
        public string RestaurantName { get; set; }

        [DisplayName("Website")]
        public string WebSite { get; set; }
        [Required]
        public string Email { get; set; }

        public string MobileNumber { set; get; }
        public string FullAddress { get; set; }

        public double latitude { set; get; }
        public double longtude { set; get; }

    }
}