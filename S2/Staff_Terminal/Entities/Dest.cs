using System;
using System.Collections.Generic;

namespace Staff_Terminal.Entities;

public partial class Dest
{
    public int Ид { get; set; }

    public int? ПользовательИд { get; set; }

    public string? Дата { get; set; }

    public int? СотрудникИд { get; set; }

    public int? Группа { get; set; }

    public string? СтатусЗаявки { get; set; }

    public string? ВремяУбытия { get; set; }

    public string? ВремяПрибытия { get; set; }

    public string? ОкончаниеПосещения { get; set; }

    public string? РазрешениеНаТерриторию { get; set; }

    public virtual Visitor? ПользовательИдNavigation { get; set; }
}
