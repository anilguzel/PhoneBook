using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Core.Entities.Concrete;

namespace PhoneBook.DataAccess.Concrete.EntityFramework.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            ToTable(@"Employee", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Surname).HasColumnName("Surname");
            Property(x => x.PhoneNumber).HasColumnName("PhoneNumber");
            Property(x => x.Title).HasColumnName("Title");
            Property(x => x.ManagerId).HasColumnName("ManagerId");

        }
    }
}
