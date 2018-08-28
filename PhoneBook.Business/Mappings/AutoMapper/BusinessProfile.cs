using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.Core.Entities.Concrete;

namespace PhoneBook.Business.Mappings.AutoMapper
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Department, Department>();
            CreateMap<Employee, Employee>();
            CreateMap<Account, Account>();

        }
    }
}
