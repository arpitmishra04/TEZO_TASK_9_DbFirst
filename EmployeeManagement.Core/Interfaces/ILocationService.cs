using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Interfaces
{
    public interface ILocationService
    {
        public bool Add(LocationModel location);
        public List<LocationModel> ViewAll();
    }
}
