﻿using System;
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
        private List<Employee>? _employees = new List<Employee>();

        private static int _id = 0;

        public IActionResult Index()
        {
            return View(_employees);
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


            _employees?.Add(employee);

            TempData["msg"] = "Employee Registred";

            return RedirectToAction("Create");
        }
    }
}
