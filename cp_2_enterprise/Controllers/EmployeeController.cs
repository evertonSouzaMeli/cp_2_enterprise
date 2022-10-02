using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cp_2_enterprise.Models;
using System.Collections;

namespace cp_2_enterprise.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> _employees = new List<Employee>();

        private static int _id = 0;

        public IActionResult Index()
        {
            List<Employee> newList = new List<Employee>(_employees);

            return View(newList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employee.Id = ++_id;
            employee.HireDate = DateTime.Now;

            int tamanho = _employees.Count;


            _employees.Add(employee);

            TempData["msg"] = "Employee Registred";

            return RedirectToAction("Create");
        }

        [HttpPost]
        public IActionResult Remove(int position)
        {
            var index = _employees.FindIndex(match: employee => employee.Id == position);

            _employees.RemoveAt(index);

            TempData["msg"] = "Employee Removed";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Employee newEmployee)
        {
            var index = _employees.FindIndex(match: employee => employee.Id == newEmployee.Id);

            newEmployee.HireDate = _employees[index].HireDate;

            _employees[index] = newEmployee;

            TempData["msg"] = "Employee Updated!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var newEmployee = _employees.Find(match: employee  => employee.Id == id);

            return View(newEmployee);
        }

        
        [HttpPost]
        public IActionResult Search(string Name)
        {
            var employee = _employees.Find(match: employee => employee.Name == Name);

            return View(employee);
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
     
    }
}

