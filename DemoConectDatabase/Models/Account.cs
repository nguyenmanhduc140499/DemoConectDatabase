using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DemoConectDatabase.Models
{
    public class Account
    {

        [Key]
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "UserPassword is required")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [StringLength(10)]
        public string RoleID { get; set; }

        internal string PasswordEncrytion(string userPassword)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword.Trim(), "MD5");
        }
    }
}