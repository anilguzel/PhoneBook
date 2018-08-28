using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBook.Core.Entities.Concrete;

namespace PhoneBook.MvcWebUI.Models
{
    public class EmployeeViewModel
    {
        public Employee Employees { get; set; }
        public List<SelectListItem> DepartmentListItem { get; set; }
        public List<SelectListItem> ManagerListItem { get; set; }
        public int DepartmentId { get; set; }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string DepartmentName { get; set; }
    }
}