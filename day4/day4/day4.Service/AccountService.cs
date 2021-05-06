using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using day4.Repository;
using day4.Model;

namespace day4.Service
{
    public class AccountService
    {
        public static Account GetAcc(int id)
        {
            return AccRepository.PullData(id);
        }

        public static List<Account> GetAllAcc()
        {
            return AccRepository.PullAllData();
        }

        //Use string/bool or similar as return type so it's easier to implement throw and fetch for errors
        public static string InsertAcc(Account data)
        {
            return AccRepository.InsertData(data);
        }
        public static string UpdateAcc(int id, Account data)
        {
            return AccRepository.UpdateData(id, data);
        }
        public static string DeleteAcc(int id)
        {
            return AccRepository.DeleteData(id);
        }
    }
}
