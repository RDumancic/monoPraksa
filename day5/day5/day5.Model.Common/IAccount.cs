using System;
using System.Collections.Generic;

namespace day5.Model.Common
{
    public interface IAccount
    {
        Guid AccountNum { get; set; }
        string Details { get; set; }
        string Status { get; set; }
    }
}
