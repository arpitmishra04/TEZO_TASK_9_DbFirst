﻿using EmployeeManagement.Model;
using ConsoleTables;
using System.Text.RegularExpressions;
using EmployeeManagement.Presentation.Validations;
using EmployeeManagement.Core.Services;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Presentation.Interfaces;

namespace EmployeeManagement.Presentation.View
{
    public class EmployeeView:IEmployeeView
    {
        private IEmployeeService employeeService;
        private ILocationService locationService;
        private IValidation validation;
        public EmployeeView(IEmployeeService _employeeService,ILocationService _locationservice,IValidation _validation) {
            this.employeeService = _employeeService;
            this.locationService = _locationservice;
            this.validation = _validation;

        }
       
      
        public int ViewAll()
        {
            List<LocationModel> locationList = locationService.ViewAll();
            List<EmployeeModel> empList = employeeService.ViewAll();
            if (empList.Count == 0 || empList == null)
            {
                Console.WriteLine("\n---------No Records found---------\n");
                return 0;
            }
            
            var table = new ConsoleTable(
                "EmpNo",
                "FullName",
                "Email",
                "JoiningDate",
                "Location",
                "JobTitle",
                "Department",
                "Manager",
                "Project");

            foreach (EmployeeModel employee in empList)
            {
                table.AddRow(
                    employee.EmpNo,
                    employee.FirstName+" "+ employee.LastName,
                    employee.Email,
                    employee.JoiningDate,
                    locationList.Find(location => location.LocationId == employee.LocationId)!.LocationName,
                    employee.JobTitle,
                    employee.Department,
                    employee.Manager,
                    employee.Project
                    );  
            }
            Console.WriteLine(table.ToString());
            return 1;

        }

        public void ViewOne()
        {
            List<EmployeeModel> emplist = employeeService.ViewAll();
            List<LocationModel> locationList = locationService.ViewAll();
            if (emplist.Count == 0)
            {
                Console.WriteLine("No Records found");
                return;
            }
            while (true) { 
            int i = 1;
            emplist.ForEach(employee => { Console.WriteLine($"{i}. {employee.EmpNo}"); i++; });
            Console.WriteLine("Enter the Option:-");
                string option = Console.ReadLine()!;
                bool isValidOption = false;

                while (true)
                {
                    if (option == "0") return;
                    isValidOption= validation.ValidateOptions(option);
                    if (isValidOption) break;
                    option = Console.ReadLine()!;
                }

                int empNo = Convert.ToInt32(option);
            if (empNo <= emplist.Count())
            {
                EmployeeModel employee = employeeService.ViewOne(emplist[empNo - 1].EmpNo);
                var table = new ConsoleTable(
               "EmpNo",
               "FirstName",
               "LastName",
               "DateOfBirth",
               "Email",
               "MobileNumber",
               "JoiningDate",
               "Location",
               "JobTitle",
               "Department",
               "Manager",
               "Project");

                table.AddRow(
                        employee.EmpNo,
                        employee.FirstName,
                        employee.LastName,
                        employee.DateOfBirth,
                        employee.Email,
                        employee.MobileNumber,
                        employee.JoiningDate,
                        locationList.Find(location=>location.LocationId==employee.LocationId)!.LocationName,
                        employee.JobTitle,
                        employee.Department,
                        employee.Manager,
                        employee.Project
                        );
                Console.WriteLine(table.ToString());
                    return;
            }
            else Console.WriteLine("Please enter a valid opotion");
            }
        }
    }
}