using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities;

public partial class Department
{
    public int DepartmentEntityId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public int DepartmentId { get; set; }
}
