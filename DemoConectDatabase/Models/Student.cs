using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoConectDatabase.Models
{
    public class Student
    {
        [Key]
        [Required(ErrorMessage ="khong duoc de trong muc nay")]
        public string StudentID { get; set; }
        [Required]
        public string StudentName { get; set; }
    }
}