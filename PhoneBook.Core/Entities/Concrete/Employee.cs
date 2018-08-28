using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Core.Entities.Abstract;

namespace PhoneBook.Core.Entities.Concrete
{
    public class Employee:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }

        public int? ManagerId { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
