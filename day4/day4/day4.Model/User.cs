using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Account Account { get; set; }

        public User() { }

        public User(int id, string name, Account acc)
        {
            this.Id = id;
            this.Name = name;
            this.Account = acc;
        }
    }
}
