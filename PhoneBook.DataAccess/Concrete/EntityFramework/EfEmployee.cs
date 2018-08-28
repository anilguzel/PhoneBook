using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Core.Entities.Concrete;
using PhoneBook.Core.Repository.EntityFramework;
using PhoneBook.DataAccess.Abstract;

namespace PhoneBook.DataAccess.Concrete.EntityFramework
{
    public class EfEmployee: EfRepository<Employee,PhoneBookContext> , IEmployeeDal
    {
    }
}
