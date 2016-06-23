using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Threading;

namespace br.corp.bonus630.ControleHorasTrabalhadas.HttpUtils
{
 
    public delegate void HttpUtilsEventHandler(object obj,HttpUtilsEventArgs e);
    public enum HttpOpType
    {
           VERSIONCHECK,
           TIMERCHECK
    }
    public class HttpToolRequest
    { 
        
        Thread httpThread;
        private bool result = false;
        public event HttpUtilsEventHandler httpRequestComplete;
        private string version;
        private string updateVersion;
        private string uri = "http://bonus630.tk/controlehorastrabalhadas/versao.php?ver=";
        private HttpOpType httpOpType;
       // public HttpOpType HttpOperationType { set { this.httpOpType = value; } }
       // public string Version { set { this.version = value; } }
        public string UpdateVersion { get { return this.updateVersion; } }
        public HttpToolRequest(){}
        public void httpAscync(string version, HttpOpType httpOpType)
        {
            this.httpOpType = httpOpType;
            this.version = version;
            
            try
            {
                httpThread = new Thread(new ThreadStart(start));
            }
            catch(WebException erro)
            {
                throw erro;
            }
            catch(ArgumentNullException erro)
            {
                throw erro;
            }
            httpThread.IsBackground = true;
            httpThread.Start();
        }
        private void start()
        {
            string _uri = "http://bonus630.tk/controlehorastrabalhadas/";
            switch(this.httpOpType)
            {
                case HttpOpType.VERSIONCHECK:
                    _uri = this.uri + this.version;
                    break;
                case HttpOpType.TIMERCHECK:
                    _uri = _uri + "timer.php";
                    break;
            }
            string result = "";
             HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(_uri);
             webRequest.ContentLength = 0;
             webRequest.Method = "GET";
             try
             {
                 using (WebResponse wr = webRequest.GetResponse())
                 {
                    
                     using (Stream st = wr.GetResponseStream())
                     {
                         using (StreamReader sr = new StreamReader(st))
                         {
                             result = sr.ReadToEnd().ToString().Trim();
                             if (!result.Contains("Atualizado"))
                             {
                                 this.result = true;
                                 this.updateVersion = result;
                             }
                             else
                                 this.updateVersion = this.version;

                         }
                     }
                 }
                 if (httpRequestComplete != null)
                     httpRequestComplete(this, new HttpUtilsEventArgs(this.result, this.updateVersion));
             }
             catch (WebException erro)
             { //throw erro; 
             }
             finally
             {
                 httpThread.Abort();
             }
         }
    }
}
