using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IDepartmentService
    {
        public bool Add(DepartmentModel location);
        public List<DepartmentModel> ViewAll();
    }
}
