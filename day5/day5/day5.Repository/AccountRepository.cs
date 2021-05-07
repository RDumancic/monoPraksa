using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day5.Repository.Common;
using day5.Model.Common;
using day5.Model;
using System.Data.SqlClient;

namespace day5.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private static readonly string ConnString = "Data Source=.;Initial Catalog=day5;Integrated Security=True";
        private static readonly SqlConnection myConnection = new SqlConnection(ConnString);
        private static SqlDataReader reader;

        public async Task<IAccount> PullDataAsync(Guid id)
        {
            IAccount account = null;

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Accounts WHERE accNum='" + id + "'");
            sqlCmd.Connection = myConnection;

            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                account = new Account();
                account.AccountNum = reader.GetGuid(0);
                account.Details = reader.GetValue(1).ToString();
                account.Status = reader.GetValue(2).ToString();
            }
            myConnection.Close();
            return account;
        }

        public async Task<List<IAccount>> PullAllDataAsync()
        {
            List<IAccount> accounts = new List<IAccount>();

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Accounts");
            sqlCmd.Connection = myConnection;

            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                accounts.Add(new Account(reader.GetGuid(0), reader.GetValue(1).ToString(), reader.GetValue(2).ToString()));
            }
            myConnection.Close();
            return accounts;
        }

        /* No need to check if account number already exists in database since it is setup on database to be a 
           uniqueidentifier with default value, the database will create an unique value by itself every time*/
        public async Task<string> InsertDataAsync(IAccount data)
        {
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO Accounts (details, status) VALUES (@details, @status)");
            sqlCmd.Connection = myConnection;

            if(data.Details.Length > 30 || data.Status == "" || data.Status.Length > 10)
            {
                return "invalid";
            }

            sqlCmd.Parameters.AddWithValue("@details", data.Details);
            sqlCmd.Parameters.AddWithValue("@status", data.Status);

            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();
            myConnection.Close();
            return "ok";
        }

        public async Task<string> UpdateDataAsync(Guid id, IAccount data)
        {
            if (data.Details.Length > 30 || data.Status == "" || data.Status.Length > 10)
            {
                return "invalid";
            }

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Accounts WHERE accNum='" + id + "'");
            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();

            if(reader.HasRows == false)
            {
                myConnection.Close();
                return "nan";
            }
            myConnection.Close();

            sqlCmd = new SqlCommand("UPDATE Accounts SET details = @details, status = @status WHERE accNum='" + id + "'");
            sqlCmd.Connection = myConnection;
            sqlCmd.Parameters.AddWithValue("@details", data.Details);
            sqlCmd.Parameters.AddWithValue("@status", data.Status);

            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();
            myConnection.Close();
            return "ok";
        }

        public async Task<string> DeleteDataAsync(Guid id)
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Accounts WHERE accNum='" + id + "'");
            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();

            if (reader.HasRows == false)
            {
                myConnection.Close();
                return "nan";
            }
            myConnection.Close();

            sqlCmd = new SqlCommand("DELETE FROM Accounts WHERE accNum='" + id + "'");
            sqlCmd.Connection = myConnection;

            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();
            myConnection.Close();
            return "ok";
        }
    }
}
