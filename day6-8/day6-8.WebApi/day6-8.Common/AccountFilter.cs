using System;
using System.Collections.Generic;

namespace day6_8.Common
{
    public class AccountFilter
    {
        public string Details { get; set; } = null;
        public string Status { get; set; } = null;

        public string GetString()
        {
            if (this.Details != null && this.Status != null)
            {
                return " WHERE details= '" + this.Details + "' AND status= '" + this.Status + "'";
            } else if(this.Details != null && this.Status == null)
            {
                return " WHERE details= '" + this.Details + "'";
            } else if(this.Details == null && this.Status != null)
            {
                return " WHERE status= '" + this.Status + "'";
            }
            else
            {
                return "";
            }
        }
    }
}
