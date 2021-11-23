using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoConectDatabase.Models
{
    public class Product
    {
        [Key]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryID { get; set; }
        public Category Category { get; set; }
    }
}