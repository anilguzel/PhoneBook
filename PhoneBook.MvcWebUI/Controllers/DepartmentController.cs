using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PhoneBook.Business.Abstract;
using PhoneBook.Core.Aspects.Postsharp.AuthorizationAspect;
using PhoneBook.Core.Entities.Concrete;

namespace PhoneBook.MvcWebUI.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentService _departmentService;
        private IEmployeeService _employeeService;

        public DepartmentController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        [SecuredOperation(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = _departmentService.GetList();
            return View(model);
        }


        [SecuredOperation(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [SecuredOperation(Roles="Admin")]
        [HttpPost]
        public ActionResult Create(Department department)
        {
            _departmentService.Add(department);
            return RedirectToAction("Index", "Department");
        }

        [SecuredOperation(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var model = _departmentService.Get(id);
            return View(model);
        }

        [SecuredOperation(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            _departmentService.Update(department);
            return RedirectToAction("Index", "Department");
        }


        [SecuredOperation(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            if (!_employeeService.HasDepartment(id))
            {
                var model = _departmentService.Get(id);
                _departmentService.Delete(model);
                return RedirectToAction("Index");
            }
            // show the error message to user
            return RedirectToAction("Index");
        }

    }
}