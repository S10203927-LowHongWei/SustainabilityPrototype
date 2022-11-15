using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SustainabilityPrototype.Models
{
    public class Student
    {
        //Student ID
        [Display(Name = "StudentId")]
        public int StudentId { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter name"), StringLength(50)]
        public string Username { get; set; }

        //Student name
        [Display(Name = "Student name")]
        [Required(ErrorMessage = "Please enter name"), StringLength(50)]
        public string StudentName { get; set; }

        //Gender
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        //Date of birth
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Field can't be empty")]
        public DateTime? DOB { get; set; }

        //Password 
        [Display(Name = "Student password")]
        public string StudentPassword { get; set; }

        //Email
        [Display(Name = "Student email address")]
        public string StudentEmailAddr { get; set; }

    }
}
