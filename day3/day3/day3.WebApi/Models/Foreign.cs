using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace day3.WebApi.Models
{
    public class Foreign
    {
        private int id;
        private string name;

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
    }
}