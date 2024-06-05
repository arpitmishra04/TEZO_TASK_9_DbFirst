using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Services
{
    public class DepartmentService:IDepartmentService
    {
        private IDepartmentDataAccess departmentDataAccess;
        public DepartmentService(IDepartmentDataAccess _departmentDataAccess) {
            this.departmentDataAccess = _departmentDataAccess;
        }

        public void Build()
        {
            TinyMapper.Bind<Department, DepartmentModel>(config=>{
                config.Ignore(src => src.DepartmentEntityId);
            }
                );
            TinyMapper.Bind<DepartmentModel, Department>();
        }
        public bool Add(DepartmentModel department)
        {
            Build();
            Department loc = TinyMapper.Map<Department>(department);
            return departmentDataAccess.Set(loc); 
        }

        public List<DepartmentModel> ViewAll()
        {
            Build();
            
            List<DepartmentModel> departments = [];
            List<Department> depts = departmentDataAccess.GetAll();

            foreach (Department dept in depts)
            {
                DepartmentModel department = TinyMapper.Map<DepartmentModel>(dept);
                departments.Add(department);

            }
            return departments;
        }
    }
}
