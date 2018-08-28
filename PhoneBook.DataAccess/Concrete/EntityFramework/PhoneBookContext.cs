using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PhoneBook.Core.Entities.Concrete;
using PhoneBook.DataAccess.Concrete.EntityFramework.Mapping;

namespace PhoneBook.DataAccess.Concrete.EntityFramework
{
    public class PhoneBookContext: DbContext
    {
        public PhoneBookContext():base("name=PhoneBookContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new AccountMap());

            modelBuilder.Entity<Employee>()
                .HasRequired<Department>(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId);
        }
    }
}
