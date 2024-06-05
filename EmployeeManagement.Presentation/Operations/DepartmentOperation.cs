using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Services;
using EmployeeManagement.Model;
using EmployeeManagement.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.Operations
{
    public class DepartmentOperation:IDepartmentOperation
    {
        private IDepartmentService departmentService;
        public DepartmentOperation(IDepartmentService _departmentservice) { 
            this.departmentService = _departmentservice;
        }
        private  readonly Random random = new Random();
        public int Add(string departmentName)
        {

            int departmentId = GenerateId();
            DepartmentModel department = new DepartmentModel { 
                DepartmentId = departmentId,
                DepartmentName = departmentName };
            
            departmentService.Add(department);
            return departmentId;
        }

        private int GenerateId()
        {

            List<DepartmentModel> departmentList = departmentService.ViewAll();
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            int id = 0;

            if (departmentList.Count() == 0)
            {
                id = random.Next(1, 1000);
            }

            else
            {
                id = departmentList[departmentList.Count() - 1].DepartmentId + random.Next(1, 900);
            }

            return id;
        }


    }
}
