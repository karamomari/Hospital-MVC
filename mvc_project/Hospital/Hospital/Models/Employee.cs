using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class Employee
{
    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public double? Salary { get; set; }

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public string Passward { get; set; } = null!;

    public string? ShiftWork { get; set; }

    public int EmpId { get; set; }

    public string JopType { get; set; } = null!;

    public string? Url { get; set; }

    public int DepId { get; set; }

    public string? Enaple { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Department Dep { get; set; } = null!;

    public virtual ICollection<EmployeePhone> EmployeePhones { get; set; } = new List<EmployeePhone>();

    public virtual HospitalSystem? UrlNavigation { get; set; }

    public virtual ICollection<Patient> Pats { get; set; } = new List<Patient>();
}
