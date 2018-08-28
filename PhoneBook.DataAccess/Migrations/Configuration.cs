using PhoneBook.Core.Entities.Concrete;

namespace PhoneBook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhoneBook.DataAccess.Concrete.EntityFramework.PhoneBookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhoneBook.DataAccess.Concrete.EntityFramework.PhoneBookContext context)
        {
            //context.Departments.AddOrUpdate(x => x.Id,
            //    new Department() {Title = "Account Executive"},
            //    new Department() {Title = "Administrative Assistant"},
            //    new Department() {Title = "Administrative Manager"},
            //    new Department() {Title = "Branch Manager"},
            //    new Department() {Title = "Business Analyst"},
            //    new Department() {Title = "Business Manager"},
            //    new Department() {Title = "Office Manager"});
        }

    }
}
