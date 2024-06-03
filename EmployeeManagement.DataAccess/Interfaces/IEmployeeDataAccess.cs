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
        public List<EmployeeModel> GetAll();
        public EmployeeModel GetOne(string employeeNumber);
        public bool Update(EmployeeModel updatedEmployee,string EmpNo);
        public bool Delete(string employeeNumber);
        public bool Set(EmployeeModel employee);

    }
}
