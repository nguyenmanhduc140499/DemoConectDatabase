using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoConectDatabase.Models
{
    public class Peopleinheritance
    {
        [Key]
        public string PeopleID { get; set; }
        public string PeopleName { get; set; }
    }
}