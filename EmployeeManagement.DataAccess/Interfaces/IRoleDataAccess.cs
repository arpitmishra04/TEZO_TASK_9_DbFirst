using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Interfaces
{
    public interface IRoleDataAccess
    {
        public List<RoleModel> GetAll();
        public bool Set(RoleModel role);
    }
}
