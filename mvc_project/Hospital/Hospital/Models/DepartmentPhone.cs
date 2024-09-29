using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class DepartmentPhone
{
    public string Phone { get; set; } = null!;

    public int DepId { get; set; }

    public virtual Department Dep { get; set; } = null!;
}
