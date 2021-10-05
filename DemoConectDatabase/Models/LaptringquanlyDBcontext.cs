﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoConectDatabase.Models
{
    public class LaptringquanlyDBcontext: DbContext
    {
        public LaptringquanlyDBcontext() : base("LaptringquanlyDBcontext")
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
            .Property(e => e.StudentID)
            .IsUnicode(false);
            modelBuilder.Entity<Student>()
            .Property(e => e.StudentName)
            .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<DemoConectDatabase.Models.Account> Accounts { get; set; }
        public System.Data.Entity.DbSet<DemoConectDatabase.Models.Roles> Roles { get; set; }
    }
}