using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.Interfaces
{
    public interface IValidation
    {
        public bool ValidateId(string employeeNumber, int validation);
        public bool ValidateNameTypeInput(string input, string inpType);
        public bool ValidateEmail(string email);
        public bool DateTypeInput(string date, string type);
        public bool ValidateOptions(string input);
        public bool ValidateMobileNumber(string mobileNumber);
        public bool ValidateLocation(string locationName);

    }
}
