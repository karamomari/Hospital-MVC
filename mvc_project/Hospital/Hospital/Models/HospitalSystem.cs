using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class HospitalSystem
{
    public string Url { get; set; } = null!;

    public virtual ICollection<Administrator> Administrators { get; set; } = new List<Administrator>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
