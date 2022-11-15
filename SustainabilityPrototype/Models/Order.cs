using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SustainabilityPrototype.Models
{
    public class Order
    {
        //OrderID
        [Display(Name = "Order id")]
        public int OrderId { get; set; }

        //StudentID
        [Display(Name = "Student id")]
        public int StudentId { get; set; }

        //StoreID
        [Display(Name = "Store id")]
        public int StoreId { get; set; }

        //OrderDateTime
        [Display(Name = "Order date time")]
        [DataType(DataType.Date)]
        public DateTime OrderDateTime { get; set; }
    }
}
