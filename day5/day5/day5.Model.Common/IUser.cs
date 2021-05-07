using System;
using System.Collections.Generic;

namespace day5.Model.Common
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Name { get; set; }
        IAccount Account { get; set; }
    }
}
