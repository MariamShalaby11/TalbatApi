using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TalbatApi.Models
{
    public enum Pay
    {
        card, visa, cash
    }
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int OrderId { get; set; }

        public DateTime OrderTime { get; set; }
        [Required]
        public Pay PaymentMethod { get; set; }

        public DateTime EstimatedTime { get; set; }

        public int SubTotal { get; set; }

        public string status { get; set; }
        public int DeliveryFee { get; set;}
        [ForeignKey("Restaurant")]
        public int RestId { get; set; }
        public virtual Restaurant Restaurant { get; set; }


        [ForeignKey("Address")]
        public int Add_Id { get; set; }
        public virtual Address Address { get; set; }
        [ForeignKey("Customer")]

        public int CustomerId { get; set; }

        public virtual Customer Customer{ get; set; }
    }
}