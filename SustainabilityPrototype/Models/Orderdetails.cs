using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SustainabilityPrototype.Models
{
    public class Orderdetails
    {
        //OrderDetailsID
        [Display(Name = "Order details id")]
        public int OrderDetailsId { get; set; }

        //OrderID
        [Display(Name = "Order id")]
        public int OrderId { get; set; }

        //FoodID
        [Display(Name = "Food id")]
        public int FoodId { get; set; }

        //OrderQty
        [Display(Name = "Order Quantity")]
        public int OrderQty { get; set; }
    }
}
