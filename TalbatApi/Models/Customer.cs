using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TalbatApi.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9_]*@[A-Za-z]+.[a-zA-Z]{2,4}", ErrorMessage = "please enter email as ****@****.***")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [DisplayName("Confirm Password")]
        public string CPassword { get; set; }

        public virtual List<RestaurantCustomer> MemberComments { get; set; }


    }
}