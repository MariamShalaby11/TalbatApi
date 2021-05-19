using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TalbatApi.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        [Required]
        public int BuildingNo { get; set; }
        [Required]
        public string Street { get; set; }

        public int floorNo { get; set; }

        public string LandMark { get; set; }
        [Required]
        public string city { get; set; }
    }
}