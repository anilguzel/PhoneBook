using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Core.Entities.Concrete;

namespace PhoneBook.DataAccess.Concrete.EntityFramework.Mapping
{
    public class DepartmentMap:EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            ToTable(@"Department", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Title).HasColumnName("Title");
        }
    }
}
