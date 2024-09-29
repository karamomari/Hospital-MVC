using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class Patient
{
    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string Email { get; set; } = null!;

    public int PatId { get; set; }

    public string Passward { get; set; } = null!;

    public string? Url { get; set; }

    public string? Enaple { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Inquiry> Inquiries { get; set; } = new List<Inquiry>();

    public virtual ICollection<PatientPhone> PatientPhones { get; set; } = new List<PatientPhone>();

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();

    public virtual HospitalSystem? UrlNavigation { get; set; }

    public virtual ICollection<Employee> Emps { get; set; } = new List<Employee>();
}
