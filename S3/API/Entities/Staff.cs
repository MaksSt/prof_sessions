using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Staff
{
    public string? Фио { get; set; }

    public string? Подразделение { get; set; }

    public string? Отдел { get; set; }

    public int КодСотрудника { get; set; }
}
