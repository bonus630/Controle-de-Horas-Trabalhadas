using System;
using System.Collections.Generic;
using System.Text;

namespace br.corp.bonus630.ControleHorasTrabalhadas.Controllers
{
    [Serializable]
    public class Hours : IComparable<Hours>
    {
        private DateTime hora_e;
        private DateTime hora_s;
        private bool inWorker;
        private int hora_id;
        private int worker_id;
        public string DayOfWeek { get {
            string dia = "";
            switch(this.hora_s.DayOfWeek)
            {
                case System.DayOfWeek.Friday:
                    dia = "Sexta-feira";
                    break;
                case System.DayOfWeek.Monday:
                    dia = "Segunda-feira";
                    break;
                     case System.DayOfWeek.Saturday:
                    dia = "Sábado";
                    break;
                     case System.DayOfWeek.Sunday:
                    dia = "Domingo";
                    break;
                     case System.DayOfWeek.Thursday:
                    dia = "Quinta-feira";
                    break;
                     case System.DayOfWeek.Tuesday:
                    dia = "Terça-feira";
                    break;
                     case System.DayOfWeek.Wednesday:
                    dia = "Quarta-feira";
                    break;
            }

            return dia; 
        } }
        public DateTime Start { get {return this.hora_s ;} set{this.hora_s = value;} }
        public DateTime End { get {return this.hora_e ;} set{this.hora_e = value;} }
        public bool InWorker { get {return this.inWorker ;} set{this.inWorker = value;} }
        public int Id { get {return this.hora_id ;} set{this.hora_id = value;} }
        public int WorkerId { get { return this.worker_id; } set { this.worker_id = value; } }
        public double TotalHours { get { return this.totalHours(); } }
        public Hours(){}
        public int CompareTo(Hours hour) 
        {
            if (hour == null)
                return 1;
            else
                return this.hora_s.CompareTo(hour.hora_s);
         }
        private double totalHours()
        {
            double result = 0;
            if(this.hora_s!=null)
               result= this.hora_e.Subtract(this.hora_s).TotalHours;
            if (result < 0)
                result = 0;
            return result;
        }
    }
}
