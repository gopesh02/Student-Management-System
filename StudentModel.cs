using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class StudentModel
    {
        [Key]
        public int Student_ID { get; set; }
        [Required(ErrorMessage = "Enter Your Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Enter Your Phone Number")]

        public int Phone { get; set; }
        [Required(ErrorMessage = "Enter Your Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Enter Your Email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Your Address")]

        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Your PinCode")]

        public int PinCode { get; set; }

       
    }
}
