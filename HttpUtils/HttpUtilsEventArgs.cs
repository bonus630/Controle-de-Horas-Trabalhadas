using System;
using System.Collections.Generic;
using System.Text;

namespace br.corp.bonus630.ControleHorasTrabalhadas.HttpUtils
{
    public class HttpUtilsEventArgs : EventArgs
    {
        private bool update = false;
        private string version = "";
        public HttpUtilsEventArgs(bool update,string version)
        {
            this.update = update;
            this.version = version;
        }
        public bool Update { get { return this.update; } }
        public string Version { get { return this.version; } }
    }
}
