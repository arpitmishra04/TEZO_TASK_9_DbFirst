using EmployeeManagement.Presentation.Interfaces;
using EmployeeManagement.Presentation.Presentation;

namespace EmployeeManagement.Presentation
{
    public class ApplicationPresenter:IApplicationPresenter
    {
        private IEmployeePresentation employeePresentation;
        private IRolePresentation rolePresentation;
      
        public ApplicationPresenter(IEmployeePresentation _employeePresentation,IRolePresentation _rolePresentation) {
            this.employeePresentation = _employeePresentation;
            this.rolePresentation = _rolePresentation;
        }
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("0. Exit \n1. Employee Management \n2. Role Management ");
                
                Console.Write("\nChoose an option: ");
                string option = Console.ReadLine()!;

                switch (option)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        employeePresentation.Start();
                        break;
                    case "2":
                        rolePresentation.Start();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

    }
}
