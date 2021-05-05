using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace day3.WebApi.Models
{
    public class Main
    {
        private int id;
        private string name;
        private int fk;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Fk
        {
            get { return this.fk; }
            set { this.fk = value; }
        }
    }
}