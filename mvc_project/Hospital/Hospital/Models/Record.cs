using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class Record
{
    public string? TreatmentAdministered { get; set; }

    public string? Medications { get; set; }

    public string? Vitals { get; set; }

    public string? Prescriptions { get; set; }

    public string? TestResults { get; set; }

    public string? TreatmentPlans { get; set; }

    public string? Diagnosis { get; set; }

    public string? PatientMedical { get; set; }

    public int PatId { get; set; }

    public int Rid { get; set; }

    public virtual Patient Pat { get; set; } = null!;
}
