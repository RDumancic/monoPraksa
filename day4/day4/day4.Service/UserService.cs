using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using day4.Repository;
using day4.Model;

namespace day4.Service
{
    public class UserService
    {
        public static User GetUser(int id)
        {
            return UserRepository.PullData(id);
        }

        public static List<User> GetAllUser()
        {
            return UserRepository.PullAllData();
        }

        //Use string/bool or similar as return type so it's easier to implement throw and fetch for errors
        public static string InsertUser(User data)
        {
            return UserRepository.InsertData(data);
        }
        public static string UpdateUser(int id, User data)
        {
            return UserRepository.UpdateData(id, data);
        }
        public static string DeleteUser(int id)
        {
            return UserRepository.DeleteData(id);
        }
    }
}
