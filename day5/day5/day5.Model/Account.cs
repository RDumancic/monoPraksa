using System;
using System.Collections.Generic;
using day5.Model.Common;

namespace day5.Model
{
    public class Account : IAccount
    {
        public Guid AccountNum { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }

        public Account(Guid acc, string det, string stat)
        {
            this.AccountNum = acc;
            this.Details = det;
            this.Status = stat;
        }

        public Account() { }

        public Account(Guid num)
        {
            this.AccountNum = num;
        }
    }
}
