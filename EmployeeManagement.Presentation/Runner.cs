using EmployeeManagement.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation
{
   public class Runner
    {
        private IApplicationPresenter presenter;

        public Runner()
        {
        }

        public Runner(ApplicationPresenter _applicationPresenter) { 
            this.presenter = _applicationPresenter;
        
        }
        public void Run() { 
            presenter.Start();

        }
    }
}
