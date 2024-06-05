using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class DepartmentDataAccess:IDepartmentDataAccess
    {
   
        public List<Department> GetAll()
        {

            List<Department> depts = [];
            using (var context = new ArpitSqlTask9CodeFirstContext())
            {
                context.Database.EnsureCreated();
                depts=context.Departments.ToList();
                context.SaveChanges();
            }

             return depts;

        }

        public bool Set(Department department)
        {
            
            using (var context = new ArpitSqlTask9CodeFirstContext())
            {
                context.Database.EnsureCreated();
                context.Departments.Add(department);
                context.SaveChanges();

            }

               
            return true;
        } 
    }
}
