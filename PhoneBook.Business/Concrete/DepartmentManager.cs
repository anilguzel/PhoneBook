using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.Business.Abstract;
using PhoneBook.Core.Entities.Concrete;
using PhoneBook.DataAccess.Abstract;

namespace PhoneBook.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private IDepartmentDal _departmentDal;
        private readonly IMapper _mapper;
        public DepartmentManager(IDepartmentDal departmentDal, IMapper mapper)
        {
            _departmentDal = departmentDal;
            _mapper = mapper;
        }
        public Department Add(Department department)
        {
            return _departmentDal.Add(department);
        }

        public bool Delete(Department department)
        {
            return _departmentDal.Delete(department);
        }

        public List<Department> GetList()
        {
            return _mapper.Map<List<Department>>(_departmentDal.GetList());
        }

        public Department Update(Department department)
        {
            return _departmentDal.Update(department);
        }

        public Department Get(int id)
        {
            return _departmentDal.Get(x=> x.Id==id);
        }
    }
}
