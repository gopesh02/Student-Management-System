using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class CourseModel
    {
        [Key]
        public int Course_ID { get; set; }
        [Required(ErrorMessage = "Enter Your Course Name")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Enter Your Coursre Fee")]
        public int CourseFee { get; set; }
        [Required(ErrorMessage = "Enter Your Course Duration")]
        public string CourseDuration { get; set; }
        [Required(ErrorMessage = "Enter Your Teacher Name")]
        public string TeacherName { get; set; }
        
    }
}
