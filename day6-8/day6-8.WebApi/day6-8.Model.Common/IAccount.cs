using System;
using System.Collections.Generic;

namespace day6_8.Model.Common
{
    public interface IAccount
    {
        Guid AccountNum { get; set; }
        string Details { get; set; }
        string Status { get; set; }
    }
}
