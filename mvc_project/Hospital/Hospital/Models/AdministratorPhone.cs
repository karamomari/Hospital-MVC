using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class AdministratorPhone
{
    public string Phone { get; set; } = null!;

    public int AddminId { get; set; }

    public virtual Administrator Addmin { get; set; } = null!;
}
