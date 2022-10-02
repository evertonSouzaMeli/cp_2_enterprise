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
            employee.Active = true;
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

    }
}

