using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoConectDatabase.Models
{
    public class Employee : Person
    {
        public String Company { get; set; }
        public String Address { get; set; }
    }
}