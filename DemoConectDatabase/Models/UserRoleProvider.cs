using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using DemoConectDatabase.Models;

namespace DemoConectDatabase.Models
{
   public class UserRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        public override string[] GetRolesForUser(string username)
        {
            using (LaptringquanlyDBcontext db = new LaptringquanlyDBcontext())
            {
                var userRoles = (from user in db.Accounts
                                 join Roles in db.Roles
                                 on user.RoleID equals Roles.RoleID
                                 where user.UserName == username
                                 select Roles.RoleID).ToArray();
                return userRoles;
            }
        }

        //public override string[] GetRolesForUser(string username)
        //{
            //throw new NotImplementedException();
       // }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}