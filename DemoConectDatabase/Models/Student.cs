using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoConectDatabase.Models
{
    public class Student
    {
        [Key]
        [Required(ErrorMessage ="khong duoc de trong muc nay")]
        public string StudentID { get; set; }
        [Required]
        [AllowHtml]
        public string StudentName { get; set; }
        //public ICollection<Account> Accounts { get; set; }
    }
}