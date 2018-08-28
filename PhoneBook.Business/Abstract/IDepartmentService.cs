using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Core.Entities.Concrete;

namespace PhoneBook.Business.Abstract
{
    public interface IDepartmentService
    {
        List<Department> GetList();
        Department Add(Department department);
        Department Update(Department department);
        bool Delete(Department department);
        Department Get(int id);
    }
}
