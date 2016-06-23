using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using br.corp.bonus630.ControleHorasTrabalhadas.HttpUtils;
using System.Text.RegularExpressions;
//using System.ComponentModel;

namespace br.corp.bonus630.ControleHorasTrabalhadas.SystemTime
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public short wYear;
        public short wMonth;
        public short wDayOfWeek;
        public short wDay;
        public short wHour;
        public short wMinute;
        public short wSecond;
        public short wMilliseconds;
    }
    
    public class SystemTimeCheck
    {
        //[DllImport("coredll.dll", SetLastError=true)]
        //public static extern bool SetSystemTime(ref SYSTEMTIME time);

       // [DllImport("kernel32.dll", SetLastError = true)]
       /// public static extern bool SetSystemTime([In] ref SYSTEMTIME st);
       // public static extern bool SetLocalTime([In] ref SYSTEMTIME st);


        public event HttpUtilsEventHandler HttpTimeReady;
        HttpToolRequest httpRequest;
        DateTime dateTime;
        private SYSTEMTIME time;
        private string result;
        private Regex rg = new Regex("(?<year>[0-9]{4})-(?<month>[0-9]{2})-(?<day>[0-9]{2}) (?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})");
        public string HttpTimeResult {get{return this.result;}}
         public SystemTimeCheck()
         {
             try
             {
                 httpRequest = new HttpToolRequest();
                 httpRequest.httpAscync("", HttpOpType.TIMERCHECK);
             }
             catch(System.Net.WebException erro)
             {
                 throw erro;
             }
             httpRequest.httpRequestComplete += httpRequest_httpRequestComplete;
         }

         public void httpRequest_httpRequestComplete(object obj, HttpUtilsEventArgs e)
         {
             if (HttpTimeReady != null && rg.IsMatch(e.Version))
             {
                 SYSTEMTIME st = new SYSTEMTIME();
                 Match mt = rg.Match(e.Version);
                 st.wYear = short.Parse(mt.Result("${year}"));
                 st.wMonth = short.Parse(mt.Result("${month}"));
                 st.wDay = short.Parse(mt.Result("${day}"));
                 st.wHour = short.Parse(mt.Result("${hour}"));
                 st.wMinute = short.Parse(mt.Result("${minute}"));
                 st.wSecond = short.Parse(mt.Result("${second}"));

                 dateTime = new DateTime(st.wYear,st.wMonth,st.wDay,st.wHour,st.wMinute,st.wSecond);

                 double minutesNow = (new TimeSpan(dateTime.Ticks)).TotalMinutes - (new TimeSpan(DateTime.Now.Ticks)).TotalMinutes;


                 if(minutesNow > 3 || minutesNow < -3)
                 {
                     this.time = st;
                     HttpTimeReady(this, new HttpUtilsEventArgs(e.Update, dateTime.ToLongDateString()+"\n"+dateTime.ToLongTimeString()));
                     //SystemTimeCheck.SetSystemTime(ref time);
                 }
             }
            
         }
            
    }
}
