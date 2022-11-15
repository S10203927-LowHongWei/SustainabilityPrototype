using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SustainabilityPrototype.Models
{
    public class Vendor
    {
        [Display(Name = "VendorID")]
        public int VendorID { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter username"), StringLength(50)]
        public string Username { get; set; }
        [Display(Name ="StallName")]
        [Required(ErrorMessage = "Please enter stall name"), StringLength(50)]
        public string StallName { get; set; }
        [Display(Name ="Password")]
        [Required(ErrorMessage = "Please enter password"), StringLength(50)]
        public string Password { get; set; }
        [Display(Name ="CanteenID")]
        [Required(ErrorMessage = "Please enter CanteenID"), StringLength(50)]
        public int CanteenID { get; set; }
    }
}
