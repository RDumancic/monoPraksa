using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4.Model
{
    public class Account
    {
        public int AccountNum { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }

        public Account (int acc, string det, string stat)
        {
            this.AccountNum = acc;
            this.Details = det;
            this.Status = stat;
        }

        public Account() { }

        public Account(int num)
        {
            this.AccountNum = num;
        }
    }
}
