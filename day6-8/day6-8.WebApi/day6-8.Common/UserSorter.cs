using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6_8.Common
{
    public class UserSorter
    {
        private string sortOrder;
        private string sortBy;
        public string SortOrder
        {
            get { return this.sortOrder; }
            set
            {
                if (value == "ASC" || value == "DESC")
                {
                    this.sortOrder = value;
                }
                else
                {
                    this.SortOrder = "";
                }
            }
        }
        public string SortBy
        {
            get { return this.sortBy; }
            set
            {
                if (value == "Name")
                {
                    this.sortBy = value;
                }
                else
                {
                    this.sortBy = null;
                }
            }
        }

        public bool isNull()
        {
            return this.sortBy == null;
        }
    }
}
