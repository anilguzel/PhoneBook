using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using PhoneBook.Business.Abstract;
using PhoneBook.Business.Concrete;
using PhoneBook.DataAccess.Abstract;
using PhoneBook.DataAccess.Concrete.EntityFramework;

namespace PhoneBook.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IEmployeeService>().To<EmployeeManager>().InSingletonScope();
            Bind<IDepartmentService>().To<DepartmentManager>().InSingletonScope();
            Bind<IAccountService>().To<AccountManager>().InSingletonScope();


            Bind<IEmployeeDal>().To<EfEmployee>();
            Bind<IDepartmentDal>().To<EfDepartment>();
            Bind<IAccountDal>().To<EfAccount>();



            Bind<DbContext>().To<PhoneBookContext>();
        }
    }
}
