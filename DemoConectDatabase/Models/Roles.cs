using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoConectDatabase.Models
{
    public partial class Roles
    {
        [StringLength(10)]
        [Key]
        public string RoleID { get; set; }
        [StringLength(10)]
        public string RoleName { get; set; }
    }
}