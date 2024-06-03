using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities;

public partial class Location
{
    public int LocationEntityId { get; set; }

    public int LocationId { get; set; }

    public string LocationName { get; set; } = null!;
}
