using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day6_8.Repository.Common;
using day6_8.Model.Common;
using day6_8.Model;
using System.Data.SqlClient;

namespace day6_8.Repository
{
    public class UserRepository : IUserRepository
    {
        private static readonly string ConnString = "Data Source=.;Initial Catalog=day5;Integrated Security=True";
        private static readonly SqlConnection myConnection = new SqlConnection(ConnString);
        private static SqlDataReader reader;

        public async Task<IUser> PullDataAsync(Guid id)
        {
            IUser User = null;

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Users WHERE id='" + id + "'");
            sqlCmd.Connection = myConnection;

            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                User = new User();
                User.Id = reader.GetGuid(0);
                User.Name = reader.GetValue(1).ToString();
                User.Account = new Account(reader.GetGuid(2));
            }
            myConnection.Close();
            return User;
        }

        public async Task<List<IUser>> PullAllDataAsync()
        {
            List<IUser> Users = new List<IUser>();

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Users");
            sqlCmd.Connection = myConnection;

            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Users.Add(new User(reader.GetGuid(0), reader.GetValue(1).ToString(), new Account(reader.GetGuid(2))));
            }
            myConnection.Close();
            return Users;
        }

        /* No need to check if user id already exists in database since it is setup on database to be a 
           uniqueidentifier with default value, the database will create an unique value by itself every time*/
        public async Task<string> InsertDataAsync(IUser data)
        {
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO Users (name) VALUES (@name)");
            sqlCmd.Connection = myConnection;

            if (data.Name == "" || data.Name.Length > 10)
            {
                return "invalid";
            }
            sqlCmd.Parameters.AddWithValue("@name", data.Name);

            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();
            myConnection.Close();
            return "ok";
        }

        public async Task<string> UpdateDataAsync(Guid id, IUser data)
        {
            if (data.Name == "" || data.Name.Length > 10)
            {
                return "invalid";
            }

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Users WHERE id='" + id + "'");
            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();

            if (reader.HasRows == false)
            {
                myConnection.Close();
                return "nan";
            }
            myConnection.Close();

            sqlCmd = new SqlCommand("UPDATE Users SET name = @name WHERE id='" + id + "'");
            sqlCmd.Connection = myConnection;
            sqlCmd.Parameters.AddWithValue("@name", data.Name);

            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();
            myConnection.Close();
            return "ok";
        }

        public async Task<string> DeleteDataAsync(Guid id)
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Users WHERE id='" + id + "'");
            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();

            if (reader.HasRows == false)
            {
                myConnection.Close();
                return "nan";
            }
            myConnection.Close();

            sqlCmd = new SqlCommand("DELETE FROM Users WHERE id='" + id + "'");
            sqlCmd.Connection = myConnection;

            await myConnection.OpenAsync();
            reader = await sqlCmd.ExecuteReaderAsync();
            myConnection.Close();
            return "ok";
        }
    }
}
