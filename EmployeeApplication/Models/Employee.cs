using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeApplication.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }
       
        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string Gender { get; set; }
        [Range(20, 70)]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Date of Joining")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DOJ { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
    public sealed class DateStartAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateStart = (DateTime)value;
            // Meeting must start in the future time.
            return (dateStart > DateTime.Now);
        }
    }
}