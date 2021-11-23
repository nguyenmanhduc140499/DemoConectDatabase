using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoConectDatabase.Models
{
    public class Category
    {
        [Key]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}