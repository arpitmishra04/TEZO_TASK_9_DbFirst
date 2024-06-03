using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;

namespace EmployeeManagement.Core.Services
{
    public class RoleService : IRoleService
    {
        private IRoleDataAccess roleDataAccess;
        public RoleService(IRoleDataAccess _roleDataAccess) { 
            this.roleDataAccess = _roleDataAccess;
        }
        public bool Add(RoleModel role)
        {
            
            return roleDataAccess.Set(role); ;
        }

        public List<RoleModel> ViewAll()
        {
            return roleDataAccess.GetAll();
        }
    }
}
