using System;
using System.Collections.Generic;
using System.Text;
using br.corp.bonus630.ControleHorasTrabalhadas.Controllers;

namespace br.corp.bonus630.ControleHorasTrabalhadas
{
    public class RelatorioItem
    {
        private int hourId;
        private DateTime hour_start;
        private DateTime hour_end;
        private bool pay;
        private string dayOfWeek;
        public string DayOfWeek { get { return this.dayOfWeek; } }
        public string DateString { get { return this.hour_start.ToShortDateString(); } }
        public string StartHour { get { return this.hour_start.ToShortTimeString(); } }
        public string EndHour { get { return this.hour_end.ToShortTimeString(); } }
        public int HourId { get { return this.hourId; } }


        public DateTime DateStart { get { return this.hour_start; } }
        public DateTime DateEnd { get { return this.hour_end; } }

        public TimeSpan HourWorked { get {
            TimeSpan result = new TimeSpan(0);
             result = this.hour_end.Subtract(this.hour_start);
             if (result < (new TimeSpan(0)))
                 result = new TimeSpan(0);
             return result;
        }
        }
        public string StatusString { get 
        {
            if (pay)
                return "Pago";
            else
                return "Não Pago";
        }
        }
        public bool Status { get { return this.pay; } }
        public RelatorioItem(Hours hora,bool pago)
        {
            this.hour_start = hora.Start;
            this.hour_end = hora.End;
            this.pay = pago;
            this.dayOfWeek = hora.DayOfWeek;
            this.hourId = hora.Id;
        }
    }
}
