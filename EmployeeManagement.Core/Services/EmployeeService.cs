using EmployeeManagement.Model;
using System.Text.RegularExpressions;
using EmployeeManagement.DataAccess;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.DataAccess.Entities;
using Nelibur.ObjectMapper;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagement.Core.Services
{
    public class EmployeeService:IEmployeeService
    {
      
        private IEmployeeDataAccess employeeDataAccess;
        public EmployeeService(IEmployeeDataAccess _employeeDataAccess) {
            this.employeeDataAccess = _employeeDataAccess;
        }
        
        private List<EmployeeModel> ?employeeList;

        public void Build()
        {
            TinyMapper.Bind<Employee, EmployeeModel>(config =>
            {
                config.Ignore(x => x.EmployeeEntityId);
                config.Ignore(x => x.RoleEntityId);

            });

            TinyMapper.Bind<EmployeeModel, Employee>();


        }
        public bool Add(EmployeeModel employee)
        {
            Build();
            Employee employeeEntity = TinyMapper.Map<Employee>(employee);
            return employeeDataAccess.Set(employeeEntity); 
        }
            

        public bool Delete(string employeeNumber)
        {

            return employeeDataAccess.Delete(employeeNumber);
        }

        public bool Edit(EmployeeModel updatedEmployee,string emp)
        {
            Build();
            Employee employeeToUpdate=employeeDataAccess.GetOne(emp);
            if (employeeToUpdate != null)
            {
                TinyMapper.Map(updatedEmployee, employeeToUpdate);
                return employeeDataAccess.Update(employeeToUpdate);
            }
            else
            {
                return false;
            }
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> ViewAll()
        {
            Build();
            List<EmployeeModel> emps = [];
            List<Employee>employees=employeeDataAccess.GetAll();
            foreach (Employee emp in employees)
            {
                emps.Add(TinyMapper.Map<EmployeeModel>(emp));

            }
            return emps ;
        }

        public EmployeeModel ViewOne(string employeeNumber)
        {
            Build();
            Employee emp = employeeDataAccess.GetOne(employeeNumber);
            EmployeeModel employee = new EmployeeModel { EmpNo = "", FirstName = "", LastName = "", DateOfBirth = "", Email = "", MobileNumber = "", JobTitle = "", Department = "", JoiningDate = "", LocationId = -1, Manager = "", Project = "" };
            TinyMapper.Map(emp, employee);
            return employee;
        }


    }
}
