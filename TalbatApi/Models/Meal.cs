using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TalbatApi.Models
{
    public class Meal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MealId { get; set; }
        [Required]
        public string Mealname { get; set; }
        [Required]
        public string MealDescription { get; set; }

        [Required]
        public int MealPrice { get; set; }
        public int Discount { get; set; }

        public byte[] Image { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}