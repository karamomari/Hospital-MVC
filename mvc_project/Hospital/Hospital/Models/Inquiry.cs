using System;
using System.Collections.Generic;

namespace Hospital.Models;

public partial class Inquiry
{
    public int InqId { get; set; }

    public string Typeinq { get; set; } = null!;

    public string Textinq { get; set; } = null!;

    public int PatId { get; set; }

    public virtual Patient Pat { get; set; } = null!;
}
