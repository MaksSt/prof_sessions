using System;
using System.Collections.Generic;

namespace PassOrderKPro.Entities;

public partial class SoloUser
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Birtday { get; set; }

    public string? Passport { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Time { get; set; }
}
