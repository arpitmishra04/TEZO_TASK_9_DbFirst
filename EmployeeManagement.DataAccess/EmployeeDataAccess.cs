using System.Data;
using System.Data.SqlClient;
using System.Text;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;
namespace EmployeeManagement.DataAccess
{
    public class EmployeeDataAccess:IEmployeeDataAccess
    {

        public void Build() {
            TinyMapper.Bind<Employee, EmployeeModel>(config =>
            {
                config.Ignore(x => x.EmployeeEntityId);
                config.Ignore(x => x.RoleEntityId);
                
            });

            TinyMapper.Bind<EmployeeModel, Employee>();


        }
       
        public  List<EmployeeModel> GetAll()
        {
            Build();
            List<Employee> employees = [];
            List<EmployeeModel> emps = [];
           

            using (var context = new ArpitSqlTask9CodeFirstContext())
                {
                context.Database.EnsureCreated();

                employees=context.Employees.ToList();

            }
                 foreach(Employee emp in employees)
            {
                emps.Add(TinyMapper.Map<EmployeeModel>(emp))    ;

            }   
               
                  return emps; 
            }



            
            
       

        public EmployeeModel GetOne(string employeeNumber)
        {

            Build();
            using (var context = new ArpitSqlTask9CodeFirstContext())
            {
                context.Database.EnsureCreated();

                Employee emp =context.Employees.FirstOrDefault(e => e.EmpNo == employeeNumber)!;
                EmployeeModel employee= TinyMapper.Map<EmployeeModel>(emp);

                return employee ;

            }


        }


        

        public bool Update(EmployeeModel updatedEmployee,string empNo)
        {
             Build();
             using (var context = new ArpitSqlTask9CodeFirstContext())
            {
                  context.Database.EnsureCreated();

                 var employeeToUpdate = context.Employees.FirstOrDefault(e => e.EmpNo == empNo);
                if (employeeToUpdate != null)
                  {
                  TinyMapper.Map(updatedEmployee, employeeToUpdate);
                 context.Entry(employeeToUpdate).State = EntityState.Modified;
                 context.SaveChanges();

                }

                return true;

            }

        }

        public bool Delete(string employeeNumber)
        {
            Build();
             using (var context = new ArpitSqlTask9CodeFirstContext())
            {
                var employeeToDelete = context.Employees.FirstOrDefault(e => e.EmpNo == employeeNumber);
                 context.Database.EnsureCreated();

                 context.Remove<Employee>(employeeToDelete!);
                 context.SaveChanges();
                return true;

            }


            
        }
        public bool Set(EmployeeModel employee)
        {
            Build();
            using (var context = new ArpitSqlTask9CodeFirstContext())
            {
                 Employee employeeEntity = TinyMapper.Map<Employee>(employee); ;
                 context.Employees.Add(employeeEntity);
                context.SaveChanges();

                return true;

            }

            
        }
    }
}
