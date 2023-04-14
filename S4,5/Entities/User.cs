using System;
using System.Collections.Generic;

namespace Guard.Entities;

public partial class User
{
    public int Ид { get; set; }

    public string? Фио { get; set; }

    public string? Пол { get; set; }

    public string? Должность { get; set; }

    public string? ТипПользователя { get; set; }

    public string? СекретноеСлово { get; set; }

    public string? Логин { get; set; }

    public string? Пароль { get; set; }

    public string? Одобрен { get; set; }

    public string? ДобавлениеДанных { get; set; }

    public string? ПросмотрДанных { get; set; }

    public string? ФормированиеОтчётов { get; set; }

    public string? Фото { get; set; }
}
