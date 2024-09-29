using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class PatientPhone
{
    public string Phone { get; set; } = null!;

    public int PatId { get; set; }

    public virtual Patient Pat { get; set; } = null!;
}
