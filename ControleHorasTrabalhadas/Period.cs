using System;
using System.Collections.Generic;
using System.Text;

namespace br.corp.bonus630.ControleHorasTrabalhadas.ControleHorasTrabalhadas
{
 
    public enum PeriodStatus
    {
        All,
        Paid,
        NotPaid
    }
    [Serializable]
    public class Period : IComparable<Period>
    {
        private int id;
        private DateTime period_start;
        private DateTime period_end;
        private DateTime period_date_p;
        private int period_worker_id;
        private char period_status;
        private double valueHour;
        private People worker;
        private static DateTime INVALIDDATE = new DateTime(1, 1, 1, 0, 0, 0);
        private List<Hours> hours = new List<Hours>();
        public int Id { get { return this.id; } set {this.id=value ;} }
        public DateTime StartDate { get { return this.period_start; } set { this.period_start = value; } }
        public DateTime EndDate { get { return this.period_end; } set { this.period_end = value; } }
        public DateTime PayDate { get { return this.period_date_p; } set { this.period_date_p = value; } }
        public int WorkerId { get { return this.period_worker_id; } set { this.period_worker_id = value; setWorker(value); } }
        public char Status { get { return this.period_status; } set { this.period_status = value; } }
        public string TotalHours { get { return this.totalHours().ToString("0.00"); } }
        public string TotalValue { get { return this.totalValue().ToString("C2"); } }
        public double ValueHour { get { return this.valueHour; } set { this.valueHour = value; } }
        public People Worker { get { return this.worker; } }
        public List<Hours> ListHours { get { return this.hours; } set { setListHours(value); } }
        /// <summary>
        /// Mostra se o período está pago
        /// </summary>
        public bool Paid { get { if (this.period_status == 'y')return true; else return false; } }
        /// <summary>
        /// Checa de o horário pertence ao período
        /// </summary>
        /// <param name="hora"></param>
        /// <returns></returns>
        public bool inPeriod(Hours hora)
        {
            bool result = false;
            if (!hora.End.Equals(Period.INVALIDDATE) && this.EndDate.Equals(Period.INVALIDDATE) && hora.Start < this.StartDate)
                return result;
            if(hora.Start >= this.StartDate && hora.End <= this.EndDate)
                result = true;
            return result;
        }
        /// <summary>
        /// Seta uma lista de horários para o período, qualquer intervalo de horários pode ser passado, pois este método so irá adicionar o horário pertencente ao período
        /// </summary>
        /// <param name="hours"></param>
        private void setListHours(List<Hours> hours)
        {
            this.hours.Clear();
            addListHours(hours);
            
        }
        public void addListHours(List<Hours> hours)
        {
            foreach (Hours hour in hours)
            {
                if (inPeriod(hour) && this.period_worker_id == hour.WorkerId)
                    this.hours.Add(hour);
            }
            hours.Sort();
        }
        public void addListHours(Hours hour)
        {
            if (inPeriod(hour) && this.period_worker_id == hour.WorkerId)
                this.hours.Add(hour);
            hours.Sort();
        }
        /// <summary>
        /// Retorna uma lista de horários de determinado faixa de tempo
        /// </summary>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        public List<Hours> getHoursListInInterval(DateTime startdate,DateTime enddate)
        {
            List<Hours> tempList = new List<Hours>();
            foreach(Hours hour in this.hours )
            {
                if(hour.Start>=startdate && hour.End <= enddate)
                {
                   tempList.Add(hour);
                }
            }
            tempList.Sort();
            return tempList;
        }
        public void autoFillHours()
        {
            this.ListHours.Clear();
            DbControl con = new DbControl();
            this.ListHours = con.getAllHourInPeriod(this.period_worker_id, this.period_start.ToString("yyyy-MM-dd HH:mm:ss"), this.period_end.ToString("yyyy-MM-dd HH:mm:ss"));
            if (this.period_status == 'n')
                this.ListHours.AddRange(con.inWork(this.period_worker_id));
            this.ListHours.Sort();
        }
        public double totalHours()
        {
            double result = 0;
            foreach(Hours hour in this.ListHours)
            {
                result += hour.TotalHours;
            }
            return result;
        }
        public double totalValue()
        {
            return this.totalHours() * this.valueHour;
        }
        private void setWorker(int workerId)
        {
            DbControl dbControl = new DbControl();
            this.worker = dbControl.getWorker(workerId);
        }
        public int CompareTo(Period period)
        {
            if (period == null)
                return 1;
            else
                return this.period_start.CompareTo(period.period_start);
        }
    }
}
