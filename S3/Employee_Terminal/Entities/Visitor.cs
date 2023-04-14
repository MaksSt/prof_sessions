using System;
using System.Collections.Generic;

namespace Employee_Terminal.Entities;

public partial class Visitor
{
    public int Ид { get; set; }

    public string? Фио { get; set; }

    public string? НомерТелефона { get; set; }

    public string? EMail { get; set; }

    public string? ДатаРождения { get; set; }

    public string? ДанныеПаспорта { get; set; }

    public string? Логин { get; set; }

    public string? Пароль { get; set; }

    public bool? ЧёрныйСписок { get; set; }

    public virtual ICollection<Dest> Dests { get; } = new List<Dest>();
}
