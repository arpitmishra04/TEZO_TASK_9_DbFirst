using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Services;
using EmployeeManagement.Model;
using EmployeeManagement.Presentation.Interfaces;
using EmployeeManagement.Presentation.Operations;
using EmployeeManagement.Presentation.Validations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.Inputs
{
    public class Input:IInput
    {
        private IEmployeeService employeeService;
        private IRoleService roleService;
        private ILocationService locationService;
        private IValidation validation;
        private ILocationOperation locationOperation;
        //private IRoleOperation roleOperation;
        public Input(IEmployeeService _employeeService, IRoleService _RoleService, ILocationService _locationService,IValidation _validation,ILocationOperation _locationOperation/*,IRoleOperation _roleOperation*/) {
            this.employeeService = _employeeService;
            this.roleService = _RoleService;
            this.locationService = _locationService;
            this.validation = _validation;
            this.locationOperation = _locationOperation;
            //this.roleOperation = _roleOperation;
        } 
      
        public string GetId(int val)
        {
           
            string employeeNumber = Console.ReadLine()!;
            bool isValidId = false;


            while (true) {
                if (employeeNumber == "0") return employeeNumber;
                isValidId = validation.ValidateId(employeeNumber, val);
                if (isValidId) return employeeNumber;
                employeeNumber = Console.ReadLine()!;

            }
            
        }
        public string GetNameTypeInput(string inp)
        {
            string input = Console.ReadLine()!;
            bool isValidName = false;

            while (true) {
                if (input == "0") return input;
                isValidName = validation.ValidateNameTypeInput(input, inp);
               if (isValidName)return input;
               input = Console.ReadLine()!;
                   
            
            }
        }

        public string GetEmail()
        {
            string email = Console.ReadLine()!;
            bool isValidEmail = false;

            while (true) {
                if (email == "0") return email;
                isValidEmail = validation.ValidateEmail(email);
                if (isValidEmail) return email;
                email = Console.ReadLine()!;    
            }
        }

        public string GetJoiningDate() {

            string joiningDate = Console.ReadLine()!;
            bool isValidJoiningDate = false;

            while (true) {
                if (joiningDate == "0") return joiningDate;
                isValidJoiningDate = validation.DateTypeInput(joiningDate,"Joining Date");
                if(isValidJoiningDate)return joiningDate;
                joiningDate = Console.ReadLine()!;
            }
        }

        public string GetDateOfBirth()
        {

            string dob = Console.ReadLine()!;
       
            bool isValidDateOfBirth = false;

            while (true)
            {
                if (dob == "0") return dob;
                isValidDateOfBirth = validation.DateTypeInput(dob, "Date of Birth");
                if (isValidDateOfBirth) return dob;
                dob = Console.ReadLine()!;
            }


        }


        public int GetLocation(string roleName) {

            List<RoleModel> roleList = roleService.ViewAll();
            List<LocationModel>locationList=locationService.ViewAll();
            Dictionary<string, Action> cases = new Dictionary<string, Action>();

            int i = 1,locationId=0;

            foreach (RoleModel role in roleList)
            {
               
                if (role.RoleName == roleName) {
                    cases.Add($"{i}", () => { locationId = role.LocationId; });
                    Console.WriteLine($"{i}. {locationList.Find(location => location.LocationId == role.LocationId)!.LocationName}");
                   
                    i++;
                }
               
            }
            Console.WriteLine($"{i}. Other");
            cases.Add($"{i}", () => {
                Console.WriteLine("Enter the name of the Location");
                string locationName = Console.ReadLine()!;
                bool isNotDuplicateLocation = false;
                while (true)
                {
                    if (locationName == "0") return ;
                    isNotDuplicateLocation = validation.ValidateLocation(locationName);
                    if (isNotDuplicateLocation) break;
                    Console.WriteLine("Cannot Enter Duplicate or Empty Location please re-enter.");
                    locationName = Console.ReadLine()!;
                }
                locationId = locationOperation.Add(locationName);
            });

            string input = Console.ReadLine()!;
            bool isValidLocation = false;

            while (true) {
                if (input == "0") return 0;
                isValidLocation =validation.ValidateOptions(input);
                if (isValidLocation) break;
                input= Console.ReadLine()!;
            }


            while (true)
            {

                if (cases.ContainsKey(input))
                {
                    cases[input].Invoke();
                    return locationId;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    input = Console.ReadLine()!;
                }
            }

           
        }
        public int GetLocation()
        {
             List<LocationModel> locationList = locationService.ViewAll();
            Dictionary<string, Action> cases = new Dictionary<string, Action>();
            int i = 1,locationId=0;
            if (locationList != null) { 
            foreach (LocationModel location in locationList)
            {
                Console.WriteLine($"{i}. {location.LocationName}");
                cases.Add($"{i}", () => { locationId = location.LocationId; });
                i++;
            }
            }
            Console.WriteLine($"{i}. Other");
            cases.Add($"{i}", () => {
                Console.WriteLine("Enter the name of the Location");
                string locationName = Console.ReadLine()!;
                bool isNotDuplicateLocation = false;
                while (true)
                {
                    if (locationName == "0") return;
                    isNotDuplicateLocation = validation.ValidateLocation(locationName);
                    if (isNotDuplicateLocation) break;
                    Console.WriteLine("Cannot Enter Duplicate or Empty Location please re-enter.");
                    locationName = Console.ReadLine()!;
                }
                locationId = locationOperation.Add(locationName);
            });

            string option = Console.ReadLine()!;
            bool isValidLocation = false;

            while (true) {
                if (option == "0") return 0;
                isValidLocation = validation.ValidateOptions(option!);
                if (isValidLocation) break;
                option = Console.ReadLine()!;
            }
            

            while (true)
            {

                if (cases.ContainsKey(option))
                {
                    cases[option].Invoke();
                    return locationId;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    option = Console.ReadLine()!;
                }
            }


        }

        public  string GetDepartment(string roleName)
        {

            List<RoleModel> roleList = roleService.ViewAll();
            List<LocationModel> locationList = locationService.ViewAll();
            Dictionary<string, Action> cases = new Dictionary<string, Action>();

            int i = 1;
            string department = "";

            foreach (RoleModel role in roleList)
            {

                if (role.RoleName == roleName)
                {
                    cases.Add($"{i}", () => { department = role.Department; });
                    Console.WriteLine($"{i}. {role.Department}");

                    i++;
                }

            }
            
            string input = Console.ReadLine()!;
            bool isValidDepartment = false;

            while (true) {
                if (input == "0") return input;
                isValidDepartment = validation.ValidateOptions(input);
                if (isValidDepartment) break;
                input = Console.ReadLine()!;
            }


            while (true)
            {

                if (cases.ContainsKey(input))
                {
                    cases[input].Invoke();
                    return department;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    input = Console.ReadLine()!;
                }
            }


        }

        public  string GetMobileNumber()
        {
            string mobileNumber = Console.ReadLine()!;
            bool isValidMobileNumber = false;

            while (true) {
                if (mobileNumber == "0") return mobileNumber;
                isValidMobileNumber = validation.ValidateMobileNumber(mobileNumber);
                if (isValidMobileNumber) return mobileNumber;
                mobileNumber = Console.ReadLine()!;
            }
        }

        public string GetRole()
        {
            int i = 1;
            List<RoleModel> roleList = roleService.ViewAll();
            if (roleList != null)
            {
                foreach (RoleModel role in roleList)
            {
                Console.WriteLine($"{i}. {role.RoleName}");
                i++;
            }
            }

            string roleInput = Console.ReadLine()!;
            bool isValidRole = false;

            while (true) {
                if (roleInput == "0") return roleInput;
                isValidRole = validation.ValidateOptions(roleInput);
                if (isValidRole) break;
                roleInput = Console.ReadLine()!;
            }

            i = 1;

            Dictionary<string, Action> cases = new Dictionary<string, Action>();


            foreach (RoleModel role in roleList!) {
                cases.Add($"{i}", () => { roleInput = role.RoleName; });
                i++;

            }
            

            while (true) { 

            if (cases.ContainsKey(roleInput))
            {
                cases[roleInput].Invoke();
                    return roleInput;
                }
            else
            {
                Console.WriteLine("Invalid Input");
                roleInput = Console.ReadLine()!;
                }
            }
        }
    }
}
