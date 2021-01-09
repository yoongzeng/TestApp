using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Diagnostics;
using Test.Models;

namespace Test.Controllers
{


    public  class HomeController: Controller
    {

        private EmployeeRepository _employeeRepository;  
         public HomeController(EmployeeRepository employeeRepository)
        {      
          _employeeRepository = employeeRepository;   
        }
        
        public ViewResult Index()
        {

            var model = _employeeRepository.GetAllEmployees();
            // Pass the list of employees to the view
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
         //   if (ModelState.IsValid)
           // {

                Employee newEmployee =
                    _employeeRepository.Add(employee);
                return RedirectToAction("Index");
          //  }
          //  return View(employee);
        }

        public IActionResult Update(int id)
        {
            Employee emp = _employeeRepository.GetEmployee(id);

            return View(emp);
        }
       [HttpPost]
        public IActionResult Update(int id, Employee em)
        {

            _employeeRepository.Update(id, em);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Employee emp = _employeeRepository.GetEmployee(id);

            return View(emp);
        }


        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {

            _employeeRepository.Delete(id);

            return RedirectToAction("Index");

        }

              
    }
}
