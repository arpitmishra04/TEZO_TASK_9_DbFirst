using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Services;
using EmployeeManagement.Model;
using EmployeeManagement.Presentation.Inputs;
using EmployeeManagement.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.Operations
{
    public class RoleOperation:IRoleOperation
    {
        private IRoleService roleService;
        private IInput input;
        public RoleOperation(IRoleService _roleService,IInput _input) {
            this.roleService = _roleService;
            this.input = _input;
        }

       
        

        public string Add()
        {
            List<RoleModel> rolelist = roleService.ViewAll();

            Console.WriteLine("Enter Role");
            string jobTitle = input.GetNameTypeInput("Role");
            if (jobTitle == "0") return "";

            Console.WriteLine("Enter Department for the Role");
            int department = input.GetDepartment();
            if (department == 0) return "";

            Console.WriteLine("Enter the description for the role");
            string description = Console.ReadLine()!;
            if (description == "0") return "";

            Console.WriteLine("Enter Location of the Employee");
            int locationId = input.GetLocation();
            if (locationId == 0) return "";


            RoleModel role = new RoleModel
            {
                RoleName = jobTitle,
                DepartmentId = department,
                Description = description,
                LocationId = locationId,

            };

            bool isSuccess = roleService.Add(role);
            if (isSuccess)
            {
                Console.WriteLine("Role Added Successfully");
            }

            return jobTitle;


        }
    }
}