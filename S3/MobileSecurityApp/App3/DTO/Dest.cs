using System;
using System.Collections.Generic;
using System.Text;

namespace App3.DTO
{
    public class Dest
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ПользовательИдNavigation.Фио);
            sb.Append(" / ");
            sb.Append("Группа: ");
            sb.Append(Группа.ToString());
            return sb.ToString();
        }
        public int Ид { get; set; }

        public int? ПользовательИд { get; set; }

        public string Дата { get; set; }

        public int? СотрудникИд { get; set; }

        public int? Группа { get; set; }

        public string СтатусЗаявки { get; set; }

        public string ВремяУбытия { get; set; }

        public string РазрешениеНаТерриторию { get; set; }

        public virtual Visitor ПользовательИдNavigation { get; set; }
    }
}
