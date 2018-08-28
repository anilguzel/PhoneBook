using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Core.Entities.Concrete;

namespace PhoneBook.Business.Abstract
{
    public interface IEmployeeService
    {
        List<Employee> GetList();
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        bool Delete(Employee employee);
        Employee Get(int id);
        List<Employee> GetManagers();
        bool IsManager(int id);
        bool HasDepartment(int id);
    }
}
