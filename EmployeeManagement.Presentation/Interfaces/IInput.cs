using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.Interfaces
{
    public interface IInput
    {
        public string GetId(int validation);
        public string GetNameTypeInput(string inp);
        public string GetEmail();
        public string GetJoiningDate();
        public string GetDateOfBirth();
        public int GetLocation(string roleName);
        public int GetLocation();
        public string GetDepartment(string roleName);
        public string GetMobileNumber();
        public string GetRole();
    }
}
