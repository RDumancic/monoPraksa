using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day6_8.Repository.Common;
using day6_8.Model.Common;
using day6_8.Model;
using System.Data.SqlClient;
using AutoMapper;

namespace day6_8.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private static readonly string ConnString = "Data Source=.;Initial Catalog=day5;Integrated Security=True";
        private static readonly SqlConnection myConnection = new SqlConnection(ConnString);
        private static SqlDataReader reader;
        private readonly IMapper mapper;

        public AccountRepository(IMapper mapper)
        {
            this.mapper = mapper;        
        }

        public async Task<IAccount> PullDataAsync(Guid id)
        {
            AccountEntity account = null;

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Accounts WHERE accNum='" + id + "'");
            sqlCmd.Connection = myConnection;

            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                account = new AccountEntity();
                account.AccountNum = reader.GetGuid(0);
                account.Details = reader.GetValue(1).ToString();
                account.Status = reader.GetValue(2).ToString();
            }
            myConnection.Close();
            return mapper.Map<IAccount>(account);
        }

        public async Task<List<IAccount>> PullAllDataAsync()
        {
            List<AccountEntity> accounts = new List<AccountEntity>();

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Accounts");
            sqlCmd.Connection = myConnection;

            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                accounts.Add(new AccountEntity(reader.GetGuid(0), reader.GetValue(1).ToString(), reader.GetValue(2).ToString()));
            }
            myConnection.Close();
            return mapper.Map<List<IAccount>>(accounts);
        }

        /* No need to check if account number already exists in database since it is setup on database to be a 
           uniqueidentifier with default value, the database will create an unique value by itself every time*/
        public async Task<string> InsertDataAsync(IAccount data)
        {
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO Accounts (details, status) VALUES (@details, @status)");
            sqlCmd.Connection = myConnection;

            if (data.Details.Length > 30 || data.Status == "" || data.Status.Length > 10)
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

            if (reader.HasRows == false)
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

    public class AccountEntity
    {
        public Guid AccountNum { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }

        public AccountEntity() { }

        public AccountEntity(Guid acc, string det, string stat)
        {
            this.AccountNum = acc;
            this.Details = det;
            this.Status = stat;
        }
    }
}
