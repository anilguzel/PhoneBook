using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Business.Abstract;
using PhoneBook.Core.Entities.Concrete;
using PhoneBook.DataAccess.Abstract;

namespace PhoneBook.Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        public Employee Add(Employee employee)
        {
            return _employeeDal.Add(employee);
        }

        public bool Delete(Employee employee)
        {
            return _employeeDal.Delete(employee);
        }

        public Employee Get(int id)
        {
            return _employeeDal.Get(x=> x.Id==id);
        }

        public List<Employee> GetList()
        {
            return _employeeDal.GetList();
        }

        public List<Employee> GetManagers()
        {
            return _employeeDal.GetList(x => x.Title != null);
        }

        public Employee Update(Employee employee)
        {
            return _employeeDal.Update(employee);
        }

        public bool IsManager(int id)
        {
            var model = _employeeDal.Get(x => x.ManagerId == id);
            if (model == null)
                return false;
            else
                return true;
        }

        public bool HasDepartment(int id)
        {
           var model= _employeeDal.Get(x => x.DepartmentId == id);
            if (model == null)
                return false;
            else
                return true;
        }
    }
}
