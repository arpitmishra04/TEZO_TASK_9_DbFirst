using EmployeeManagement.Model;
using System.Text.RegularExpressions;
using EmployeeManagement.DataAccess;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess.Interfaces;
namespace EmployeeManagement.Core.Services
{
    public class EmployeeService:IEmployeeService
    {
        private IEmployeeDataAccess employeeDataAccess;
        public EmployeeService(IEmployeeDataAccess _employeeDataAccess) {
            this.employeeDataAccess = _employeeDataAccess;
        }
        
        private List<EmployeeModel> ?employeeList; 

        
        public bool Add(EmployeeModel employee)
        {
            
            return employeeDataAccess.Set(employee); ;
        }
            

        public bool Delete(string employeeNumber)
        {
            return employeeDataAccess.Delete(employeeNumber);
        }

        public bool Edit(EmployeeModel updatedEmployee,string emp)
        {
            return employeeDataAccess.Update(updatedEmployee,emp);
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> ViewAll()
        {
            return employeeDataAccess.GetAll();
        }

        public EmployeeModel ViewOne(string employeeNumber)
        {
            return employeeDataAccess.GetOne(employeeNumber);
        }


    }
}
