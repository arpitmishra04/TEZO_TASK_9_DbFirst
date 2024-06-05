using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities;

public partial class Role
{
    public int RoleEntityId { get; set; }

    public string RoleName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string Description { get; set; } = null!;

    public int LocationId { get; set; }
}
