using System;
using System.Collections.Generic;

namespace day6_8.Model.Common
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Name { get; set; }
        IAccount Account { get; set; }
    }
}