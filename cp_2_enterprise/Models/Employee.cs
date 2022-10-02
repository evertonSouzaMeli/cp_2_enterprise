using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace cp_2_enterprise.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Salary { get; set; }

        public Gender? UserGender { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        public DateTime HireDate { get; set; }

        public enum Gender
        {
            MALE, FEMALE
        }
    }
}

