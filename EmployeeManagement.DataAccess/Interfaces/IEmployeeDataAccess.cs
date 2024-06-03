using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Interfaces
{
    public interface IEmployeeDataAccess
    {
        public List<Employee> GetAll();
        public Employee GetOne(string employeeNumber);
        public bool Update(Employee updatedEmployee);
        public bool Delete(string employeeNumber);
        public bool Set(Employee employee);

    }
}
