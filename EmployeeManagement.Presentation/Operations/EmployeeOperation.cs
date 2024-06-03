using EmployeeManagement.Model;
using System.Xml.Schema;
using System.Text.RegularExpressions;
using EmployeeManagement.Presentation.Inputs;
using EmployeeManagement.Presentation.View;
using EmployeeManagement.Presentation.Validations;
using EmployeeManagement.Core.Services;
using System.Reflection;
using EmployeeManagement.Presentation.Interfaces;
using EmployeeManagement.Core.Interfaces;
using System.Collections.Generic;
namespace EmployeeManagement.Presentation.Operations
{
   
    public class EmployeeOperation:IEmployeeOperation
    {
        private string emp="", jobTitle="", firstName = "", lastName = "", dob = "", email = "", mobile = "", joiningDate = "",department = "" ,manager = "",project = ""; 
        private int locationID=0;
        private  bool isExit = false;
        private IEmployeeView employeeView;
        private IValidation validation;
        private Dictionary<string, Action> methodList = new Dictionary<string, Action>();
       private IInput input;
        private IEmployeeService employeeService;
         

        public EmployeeOperation(IInput _input,IEmployeeService _employeeService,IEmployeeView employeeView,IValidation _validation)
        {
            this.input = _input;
            this.employeeService = _employeeService;
            this.employeeView = employeeView;
            this.validation = _validation;
            MethodList();
        }
        private void EmployeeNumber()
        {
            Console.WriteLine("\n Enter Employee Number (eg:TZXXXX)");
            emp = input.GetId(0);
            if (emp == "0") isExit=true;
        }
        private void FirstName()
        {
            Console.WriteLine("\n Enter First Name:");
            firstName = input.GetNameTypeInput("FirstName");
            if (firstName == "0") isExit=true;
        }

        private void LastName() {
            Console.WriteLine("\n Enter Last Name:");
             lastName = input.GetNameTypeInput("LastName");
            if (lastName == "0") isExit=true;
        }

        private void DOB()
        {
            Console.WriteLine("\n Enter Date of Birth (DD/MM/YYYY)");
            dob = input.GetDateOfBirth();
            if (dob == "0") isExit = true;
        }

        private void Email()
        {
            Console.WriteLine("\n Enter Email:");
             email = input.GetEmail();
            if (email == "0") isExit = true;
        }


        private void Phone()
        {
            Console.WriteLine("\n Enter Mobile Number:");
             mobile = input.GetMobileNumber();
            if (mobile == "0") isExit = true;
        }

        private void JoiningDate()
        {
            Console.WriteLine("\n Enter Employee Joining Date (DD/MM/YYYY)*");
             joiningDate = input.GetJoiningDate();
            if (joiningDate == "0") isExit = true;
        }

        private void JobTitle()
        {
            Console.WriteLine("\n Enter Job Title:");
           jobTitle = input.GetRole();
            if (jobTitle == "0") isExit = true;

        }

        private void Location()
        {
            Console.WriteLine("\n Enter Employee Location:");
            locationID = input.GetLocation();
            if (locationID == 0) isExit = true;

        }

        private void Department()
        {
            Console.WriteLine("\n Enter Employee Department:");
             department = input.GetDepartment(jobTitle);
            if (department == "0") isExit = true;

        }

        private void Manager()
        {
            Console.WriteLine("\n Enter the Name of the Manager for Employee:");
             manager = Console.ReadLine()!;
            if (manager == "0") isExit = true;

        }

        private void Project()
        {
            Console.WriteLine("\n Enter the Project assigned to the Employee:");
             project = Console.ReadLine()!;
            if (project == "0") isExit = true;

        }


        private Dictionary<string, Action> MethodList()
        {
            methodList.Add("1", EmployeeNumber);
            methodList.Add("2", FirstName);
            methodList.Add("3", LastName);
            methodList.Add("4", DOB);
            methodList.Add("5", Email);
            methodList.Add("6", Phone);
            methodList.Add("7", JoiningDate);
            methodList.Add("8", JobTitle);
            methodList.Add("9", Location);
            methodList.Add("10", Department);
            methodList.Add("11", Manager);
            methodList.Add("12", Project);

            return methodList;  
        }

        

        public void Add()
        {
            
            Console.WriteLine("Initiating Employee Addition procedure,please type \"0\" to return to the previous menu anytime");      

            foreach(string key in methodList.Keys)
            {
                if (isExit) { 
                    isExit = false;
                    return; 
                }
                    methodList[key].Invoke();
            }
          
            

            EmployeeModel employee = new EmployeeModel {
                EmpNo=emp.ToUpper(),
                FirstName=firstName,
                LastName=lastName,
                DateOfBirth=dob,
                Email=email,
                MobileNumber=mobile,
                JoiningDate=joiningDate,
                LocationId=locationID,
                JobTitle=jobTitle,
                Department=department,
                Manager=manager,
                Project=project
            };
            bool isSuccess= employeeService.Add(employee);
            if (isSuccess)
            {
                Console.WriteLine("\n Employee Added Successfully");
            }

        }



        public  void Update()
        {
            
            List<EmployeeModel> emplist = employeeService.ViewAll();
            if (emplist.Count == 0)
            {
                Console.WriteLine("\n---------No Records found---------\n");
                return;
            }
            
            bool isUpdate = true;
            //int locationId = 0;
            employeeView.ViewAll();
            Console.WriteLine("Initiating Employee Updation procedure,please type \"0\" to return to return to the previous menu anyime");

            Console.WriteLine("Enter the employee Number of the employee whose record needs to be updated:-");
            string emp = input.GetId(1);
            if (emp == "0") return;


            while (isUpdate)
            {

            Console.WriteLine($"Select the field that you want to update for the employee with Employee Number {emp}");
            Console.WriteLine("0. End Updation \n1. First Name \n2. Last Name \n3. Date of Birth \n4. Email \n5. Mobile Number \n6. Joining Date \n7. Job Title \n8. Employee Location \n9. Employee Department \n10. Employee Manager \n11. Employee Project");

                string option = Console.ReadLine()!;
                bool isValidOption = false;

                while (true) {
                    if (option == "0") { isUpdate = false; break; }
                    isValidOption=validation.ValidateOptions(option);
                    if (isValidOption)break;
                    option = Console.ReadLine()!;
                }
            
                


                foreach(string key in methodList.Keys)
                {
                    if (option.Equals("0"))
                    {
                        isExit = false;
                        break;
                    }
                    string keyCheck= (Convert.ToInt32(option) + 1).ToString();
                    if (keyCheck.Equals(key))
                    {
                        methodList[key].Invoke();
                        break;
                    }
                }
            

            }

            bool isSuccess = false;
            
            foreach (EmployeeModel employee in emplist)
            {

                if (employee.EmpNo == emp)
                {
                    if (!string.IsNullOrWhiteSpace(firstName)) {
                       employee.FirstName = firstName;
                        
                    }
                    if (!string.IsNullOrWhiteSpace(lastName)) { 
                        employee.LastName = lastName;
                       
                    }
                    if (!string.IsNullOrWhiteSpace(dob)) { 
                        employee.DateOfBirth = dob;
                       
                    }
                    if (!string.IsNullOrWhiteSpace(email)) {
                        employee.Email = email;
                        
                    }
                    if (!string.IsNullOrWhiteSpace(mobile)) { 
                        employee.MobileNumber = mobile;
                       
                    }
                    if (!string.IsNullOrWhiteSpace(joiningDate)) { 
                        employee.JoiningDate = joiningDate;
                       
                    }
                    if (locationID != 0) {
                        employee.LocationId = locationID;
                       
                    }
                    if (!string.IsNullOrWhiteSpace(jobTitle)) { 
                        employee.JobTitle = jobTitle;
                        
                    }
                    if (!string.IsNullOrWhiteSpace(department)) { 
                        employee.Department = department;
                       
                    }
                    if (!string.IsNullOrWhiteSpace(manager)) { 
                        employee.Manager = manager;
                        
                    }
                    if (!string.IsNullOrWhiteSpace(project)) { 
                        employee.Project = project;
                       
                    }

                    isSuccess = employeeService.Edit(employee,emp);
                }
            }

           
            if (isSuccess)
            {
                Console.WriteLine($"Employee with employee number {emp} updated sucessfully");
            }

        }


        public  void Delete()
        {
            int recordsCheck=employeeView.ViewAll();
            if (recordsCheck == 0) return;
            Console.WriteLine("Initiating Employee Deletion procedure,please type \"0\" to return to return to the previous menu anyime");
            Console.WriteLine("Enter the Employee Number:-");
            string empNo = input.GetId(1);
            if (empNo == "0") return;
            bool isSuccess=employeeService.Delete(empNo);
            if (isSuccess)
            {
                Console.WriteLine("Employee Deleted Sucessfully");
            }
        }

    }
}
