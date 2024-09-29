using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class Administrator
{
    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Address { get; set; }

    public string Email { get; set; } = null!;

    public double? Salary { get; set; }

    public string Passward { get; set; } = null!;

    public int AddminId { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<AdministratorPhone> AdministratorPhones { get; set; } = new List<AdministratorPhone>();

    public virtual HospitalSystem? UrlNavigation { get; set; }
}
