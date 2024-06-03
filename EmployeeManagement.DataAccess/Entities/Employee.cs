using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities;

public partial class Employee
{
    public int EmployeeEntityId { get; set; }

    public string EmpNo { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string DateOfBirth { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string JoiningDate { get; set; } = null!;

    public int LocationId { get; set; }

    public int RoleEntityId { get; set; }

    public string JobTitle { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Manager { get; set; } = null!;

    public string Project { get; set; } = null!;
}
