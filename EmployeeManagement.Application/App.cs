using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Services;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Presentation;
using EmployeeManagement.Presentation.Inputs;
using EmployeeManagement.Presentation.Interfaces;
using EmployeeManagement.Presentation.Operations;
using EmployeeManagement.Presentation.Presentation;
using EmployeeManagement.Presentation.Validations;
using EmployeeManagement.Presentation.View;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Application
{

   internal class App
    {

        static void Main()
    {
            ServiceCollection services = new ServiceCollection();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IEmployeeDataAccess, EmployeeDataAccess>();
            services.AddTransient<ILocationDataAccess, LocationDataAccess>();
            services.AddTransient<IDepartmentDataAccess, DepartmentDataAccess>();
            services.AddTransient<IRoleDataAccess, RoleDataAccess>();
            services.AddTransient<IInput, Input>();
            services.AddTransient<IValidation, Validation>();
            services.AddTransient<IEmployeeOperation, EmployeeOperation>();
            services.AddTransient<IEmployeeView, EmployeeView>();
            services.AddTransient<IEmployeePresentation, EmployeePresentation>();
            services.AddTransient<ILocationOperation, LocationOperation>();
            services.AddTransient<IDepartmentOperation, DepartmentOperation>();
            services.AddTransient<IRoleOperation, RoleOperation>();
            services.AddTransient<IRolePresentation, RolePresentation>();
            services.AddTransient<IRoleView, RoleView>();
            services.AddTransient<ApplicationPresenter>();


            using (ServiceProvider serviceProvider = services.BuildServiceProvider()) { 

                // Resolve and run the App
                var app =  serviceProvider.GetRequiredService<ApplicationPresenter>();
                app.Start();
            }

        }

        



    }
}