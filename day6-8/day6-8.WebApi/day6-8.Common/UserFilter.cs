using System;
using System.Collections.Generic;

namespace day6_8.Common
{
    public class UserFilter : IUserFilter
    {
        public string Name { get; set; } = null;

        public string GetString()
        {
            if (this.Name != null)
            {
                return " WHERE name= '" + this.Name + "'";
            }
            else
            {
                return "";
            }
        }
    }
}
