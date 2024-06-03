using EmployeeManagement.Presentation.Interfaces;
using EmployeeManagement.Presentation.Operations;
using EmployeeManagement.Presentation.View;

namespace EmployeeManagement.Presentation.Presentation
{
    public class EmployeePresentation : IEmployeePresentation
    {
        private IEmployeeOperation employeeOperation;
        private IEmployeeView employeeView;
        public EmployeePresentation(IEmployeeOperation _employeeOpertion,IEmployeeView _employeeView) {
            this.employeeOperation = _employeeOpertion;
            this.employeeView = _employeeView;
        }
       
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("0. Go Back \n1. Add Employee \n2. View All Employee \n3. View specific Employee \n4. Edit Employee \n5. Delete Employee");
                
                Console.Write("Choose an option: ");
                string option = Console.ReadLine()!;

                switch (option)
                {
                    case "0": return;

                    case "1":
                        employeeOperation.Add();

                        break;
                    case "2":
                        employeeView.ViewAll();

                        break;
                    case "3":
                        employeeView.ViewOne();

                        break;
                    case "4":employeeOperation.Update();

                        break;
                    case "5":employeeOperation.Delete();

                        break;
            
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
