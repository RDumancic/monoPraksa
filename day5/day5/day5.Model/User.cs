using System;
using System.Collections.Generic;
using day5.Model.Common;


namespace day5.Model
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IAccount Account { get; set; }

        public User() { }

        public User(Guid id, string name, Account acc)
        {
            this.Id = id;
            this.Name = name;
            this.Account = acc;
        }
    }
}
