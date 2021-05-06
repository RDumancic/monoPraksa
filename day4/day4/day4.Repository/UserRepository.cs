using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using day4.Model;

namespace day4.Repository
{
    public class UserRepository
    {
        private static readonly string ConnString = "Data Source=.;Initial Catalog=day4;Integrated Security=True";
        private static readonly SqlConnection myConnection = new SqlConnection(ConnString);

        public static User PullData(int id)
        {
            User user = new User();

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Users WHERE id=" + id + "");
            sqlCmd.Connection = myConnection;

            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                user.Id = Convert.ToInt32(reader.GetValue(0));
                user.Name = reader.GetValue(1).ToString();
                user.Account = new Account(Convert.ToInt32(reader.GetValue(2)));
            }
            myConnection.Close();
            return user;
        }

        public static List<User> PullAllData()
        {
            List<User> users = new List<User>();

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Users");
            sqlCmd.Connection = myConnection;

            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString(), new Account(Convert.ToInt32(reader.GetValue(2)))));
            }
            myConnection.Close();
            return users;
        }

        public static string InsertData(User data)
        {
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO Users (id, name, accNum) VALUES (@id, @name, @accNum)");
            sqlCmd.Connection = myConnection;

            sqlCmd.Parameters.AddWithValue("@id", data.Id);
            sqlCmd.Parameters.AddWithValue("@name", data.Name);
            sqlCmd.Parameters.AddWithValue("@accNum", data.Account);

            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            myConnection.Close();
            return "ok";
        }

        public static string UpdateData(int id, User data)
        {
            SqlCommand sqlCmd = new SqlCommand("UPDATE Users SET name = @name WHERE id=" + id + "");
            sqlCmd.Connection = myConnection;

            sqlCmd.Parameters.AddWithValue("@details", data.Name);

            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            myConnection.Close();
            return "ok";
        }

        public static string DeleteData(int id)
        {
            SqlCommand sqlCmd = new SqlCommand("DELETE FROM Users WHERE id=" + id + "");
            sqlCmd.Connection = myConnection;

            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            myConnection.Close();
            return "ok";
        }
    }
}
