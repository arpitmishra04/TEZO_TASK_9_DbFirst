using EmployeeManagement.Presentation.Interfaces;
using EmployeeManagement.Presentation.Operations;
using EmployeeManagement.Presentation.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.Presentation
{
   public class RolePresentation:IRolePresentation
    {
        private IRoleOperation roleOperation;
        private IRoleView roleView;
        public RolePresentation(IRoleOperation _roleOperation,IRoleView _roleView) { 
            this.roleOperation = _roleOperation;
            this.roleView = _roleView;
        }
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("0. Go Back \n1. Add Role \n2. View All Roles \nChoose an option: ");
                
                string option = Console.ReadLine()!;
                switch (option)
                {
                    case "0":
                        return;
                    case "1":
                        roleOperation.Add();
                        break;
                    case "2":
                        roleView.ViewAll();
                        break;
                    
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
