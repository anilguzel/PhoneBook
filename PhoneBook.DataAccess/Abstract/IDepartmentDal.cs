using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Core.Entities.Concrete;
using PhoneBook.Core.Repository;

namespace PhoneBook.DataAccess.Abstract
{
    public interface IDepartmentDal: IRepository<Department>
    {
    }
}
