using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Core.Entities.Abstract;

namespace PhoneBook.Core.Entities.Concrete
{
    public class Department:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
