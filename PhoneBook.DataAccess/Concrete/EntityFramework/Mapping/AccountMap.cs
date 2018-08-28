using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Core.Entities.Concrete;

namespace PhoneBook.DataAccess.Concrete.EntityFramework.Mapping
{
    public class AccountMap:EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            ToTable(@"Account", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.UserName).HasColumnName("UserName");
            Property(x => x.Password).HasColumnName("Password");

        }
    }
}
