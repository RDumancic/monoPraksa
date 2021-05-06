using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using day4.Model;

namespace day4.Repository
{
    public class AccRepository
    {
        private static readonly string ConnString = "Data Source=.;Initial Catalog=day4;Integrated Security=True";
        private static readonly SqlConnection myConnection = new SqlConnection(ConnString);

        public static Account PullData(int id)
        {
            Account account = new Account();

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Accounts WHERE accNum=" + id + "");
            sqlCmd.Connection = myConnection;

            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                account.AccountNum = Convert.ToInt32(reader.GetValue(0));
                account.Details = reader.GetValue(1).ToString();
                account.Status = reader.GetValue(2).ToString();
            }
            myConnection.Close();
            return account;
        }

        public static List<Account> PullAllData()
        {
            List<Account> accounts = new List<Account>();

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Accounts");
            sqlCmd.Connection = myConnection;

            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                accounts.Add(new Account(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString(), reader.GetValue(2).ToString()));
            }
            myConnection.Close();
            return accounts;
        }

        public static string InsertData(Account data)
        {
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO Accounts (accNum, details, status) VALUES (@accNum, @details, @status)");
            sqlCmd.Connection = myConnection;

            sqlCmd.Parameters.AddWithValue("@accNum", data.AccountNum);
            sqlCmd.Parameters.AddWithValue("@details", data.Details);
            sqlCmd.Parameters.AddWithValue("@status", data.Status);

            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            myConnection.Close();
            return "ok";
        }

        public static string UpdateData(int id, Account data)
        {
            SqlCommand sqlCmd = new SqlCommand("UPDATE Accounts SET details = @details, status = @status WHERE accNum=" + id + "");
            sqlCmd.Connection = myConnection;

            sqlCmd.Parameters.AddWithValue("@details", data.Details);
            sqlCmd.Parameters.AddWithValue("@status", data.Status);

            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            myConnection.Close();
            return "ok";
        }

        public static string DeleteData(int id)
        {
            SqlCommand sqlCmd = new SqlCommand("DELETE FROM Accounts WHERE accNum=" + id + "");
            sqlCmd.Connection = myConnection;

            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            myConnection.Close();
            return "ok";
        }
    }
}
