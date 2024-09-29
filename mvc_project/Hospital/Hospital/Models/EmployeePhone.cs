using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class EmployeePhone
{
    public string Phone { get; set; } = null!;

    public int EmpId { get; set; }

    public virtual Employee Emp { get; set; } = null!;
}
