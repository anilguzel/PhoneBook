using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PhoneBook.Business.Abstract;
using PhoneBook.Core.Aspects.Postsharp.AuthorizationAspect;
using PhoneBook.Core.Entities.Concrete;
using PhoneBook.MvcWebUI.Models;

namespace PhoneBook.MvcWebUI.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        private IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }


        // GET: Employee
        public ActionResult Index()
        {
            return View(_employeeService.GetList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var model = new EmployeeViewModel();
            model.Employees = _employeeService.Get(id);
            int mId = model.Employees.ManagerId.IfNotNull(x => x.Value);
            if (mId != 0)
            {
                model.ManagerName = _employeeService.Get(mId).Name;
            }

            int diD = model.Employees.DepartmentId.IfNotNull(x => x.Value);
            if(diD != 0)
            {
                model.DepartmentName = _departmentService.Get(diD).Title;
            }
            return View(model);
        }
        [SecuredOperation(Roles = "Admin")]
        // GET: Employee/Create
        public ActionResult Create()
        {
            var model = new EmployeeViewModel();
            List<Department> departments = _departmentService.GetList();
            model.DepartmentListItem = (from department in departments
                                        select new SelectListItem
                                        {
                                            Value = department.Id.ToString(),
                                            Text = department.Title
                                        }).ToList();
            model.DepartmentListItem.Insert(0, new SelectListItem { Value = "", Text = "Select Department", Selected = true });

            List<Employee> managers = _employeeService.GetManagers();
            model.ManagerListItem = (from manager in managers
                                     select new SelectListItem
                                     {
                                         Value = manager.Id.ToString(),
                                         Text = manager.Name + " " + manager.Surname,
                                     }).ToList();
            model.ManagerListItem.Insert(0, new SelectListItem { Value = "", Text = "Select Manager", Selected = true });
            return View(model);
        }
        [SecuredOperation(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(EmployeeViewModel model)
        {
            model.Employees.DepartmentId = model.DepartmentId;
            model.Employees.ManagerId = model.ManagerId;

            if (ModelState.IsValid)
            {
                _employeeService.Add(model.Employees);
                return RedirectToAction("Index");
            }

            return View();
        }
        [SecuredOperation(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var model = new EmployeeViewModel();
            model.Employees = _employeeService.Get(id);

            List<Department> departments = _departmentService.GetList();
            model.DepartmentListItem = (from department in departments
                                        select new SelectListItem
                                        {
                                            Value = department.Id.ToString(),
                                            Text = department.Title
                                        }).ToList();
            model.DepartmentListItem.Insert(0, new SelectListItem { Value = "", Text = "Change Department", Selected = true });


            List<Employee> managers = _employeeService.GetManagers();
            model.ManagerListItem = (from manager in managers
                                     select new SelectListItem
                                     {
                                         Value = manager.Id.ToString(),
                                         Text = manager.Name + " " + manager.Surname,
                                     }).ToList();
            model.ManagerListItem.Insert(0, new SelectListItem { Value = "", Text = "Change Manager", Selected = true });

            if (model.Employees == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [SecuredOperation(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel model)
        {
            //handlin error
            if (model.DepartmentId != 0)
            {
                model.Employees.DepartmentId = model.DepartmentId;
            }
            else if (model.ManagerId != 0)
            {
                model.Employees.ManagerId = model.ManagerId;
            }
            
            try
            {
                _employeeService.Update(model.Employees);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            { }
            return View();
        }
        [SecuredOperation(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            if (!_employeeService.IsManager(id))
            {
                var model = _employeeService.Get(id);
                if (_employeeService.Delete(model))
                {
                    return RedirectToAction("Index");
                }
            }

            // show the error message to user
            return RedirectToAction("Index");

        }

    }
}
