using System;
using System.Collections.Generic;

namespace PassOrderKPro.Entities;

public partial class Staff
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public string? Unit { get; set; }

    public string? Depart { get; set; }

    public int? CodeStaff { get; set; }
}
