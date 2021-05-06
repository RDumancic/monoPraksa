using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4.Model.Common
{
    interface IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Account Account { get; set; }
    }
}
