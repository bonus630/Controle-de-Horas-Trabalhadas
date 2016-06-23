using System;
using System.Collections.Generic;
using System.Text;

namespace br.corp.bonus630.ControleHorasTrabalhadas.ControleHorasTrabalhadas
{
    [Serializable]
    public class People
    {
        private int id;
        private string name;
        private string photoName;
        private bool active;
        private bool working;
        public int Id { get{return this.id;} set{this.id = value;} }
        public string Name { get{return this.name;} set{this.name = value;} }
        public string  PhotoName { get{return this.photoName;} set{this.photoName = value;} }
        public bool Active { get { return this.active; } set {this.active =value; } }

        public bool Working { get { return this.working; } set { this.working = value; } }
        public People(int id, string name, string photoName, string active,bool working)
        {
            this.id = id;
            this.name = name;
            this.photoName = photoName;
            if (active == "y")
                this.active = true;
            if (active == "n")
                this.active = false;
            this.working = working;
        }
        public People() { }
    }
}
