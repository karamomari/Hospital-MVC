using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class Appointment
{
    public int AppId { get; set; }

    public DateOnly Date { get; set; }

    public int PatId { get; set; }

    public int? Iddoctor { get; set; }

    public virtual Employee? IddoctorNavigation { get; set; }

    public virtual Patient Pat { get; set; } = null!;
}
