using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SustainabilityPrototype.Models
{
    public class Canteen
    {
        //CanteenID
        [Display(Name = "id")]
        public int CanteenId { get; set; }

        //Canteen Name
        [Display(Name = "Canteen name")]
        [Required(ErrorMessage = "Please enter name"), StringLength(50)]
        public string CanteenName { get; set; }

        //Location
        [Display(Name = "Location")]
        [Required(ErrorMessage = "Please location"), StringLength(50)]
        public string Location { get; set; }
    }
}
