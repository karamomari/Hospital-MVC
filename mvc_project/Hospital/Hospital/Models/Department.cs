using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class Department
{
    public int DepId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<DepartmentPhone> DepartmentPhones { get; set; } = new List<DepartmentPhone>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
