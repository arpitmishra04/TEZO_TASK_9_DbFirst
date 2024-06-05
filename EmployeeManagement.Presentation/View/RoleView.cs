using ConsoleTables;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Services;
using EmployeeManagement.Model;
using EmployeeManagement.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.View
{
    public class RoleView:IRoleView
    {
        private IRoleService roleService;
        private ILocationService locationService;
        private IDepartmentService departmentService;
        public RoleView(IRoleService _roleService,ILocationService _locationService, IDepartmentService _departmentService) {
            this.roleService = _roleService;
            this.locationService = _locationService;
            this.departmentService = _departmentService;

        }
        
       
        public void ViewAll() 
        {

            List<RoleModel> roleList = roleService.ViewAll();
            List <LocationModel>locationList= locationService.ViewAll();
            List<DepartmentModel> departmentList = departmentService.ViewAll();
            var table = new ConsoleTable(
                "Role Name",
                "Department",
                "Description",
                 "Location"
                   );

            foreach (RoleModel role in roleList)
            {
                table.AddRow(
                    
                    role.RoleName,
                    departmentList.Find(department => department.DepartmentId == role.DepartmentId)!.DepartmentName,
                    role.Description,
                    locationList.Find(location=>location.LocationId== role.LocationId)!.LocationName
                    
                    );



            }
            Console.WriteLine(table.ToString());


        }
        
    }
}
