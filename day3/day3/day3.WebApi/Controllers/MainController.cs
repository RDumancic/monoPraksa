using day3.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace day3.WebApi.Controllers
{
    public class MainController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetForeignData(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Data Source=.;Initial Catalog=day3;Integrated Security=True";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from MainData where id=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Main item = null;
            while (reader.Read())
            {
                item = new Main();
                item.Id = Convert.ToInt32(reader.GetValue(0));
                item.Name = reader.GetValue(1).ToString();
                item.Fk = Convert.ToInt32(reader.GetValue(2));
            }
            myConnection.Close();
            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid id");
            }
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        [HttpPost]
        public HttpResponseMessage AddForeignData([FromBody] Main data)
        {
            if (data != null)
            {
                if (data.Name != "")
                {
                    SqlConnection myConnection = new SqlConnection();
                    myConnection.ConnectionString = @"Data Source=.;Initial Catalog=day3;Integrated Security=True";
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = "INSERT INTO MainData (name,fk) Values (@name,@fk)";
                    sqlCmd.Connection = myConnection;

                    sqlCmd.Parameters.AddWithValue("@Name", data.Name);
                    sqlCmd.Parameters.AddWithValue("@fk", data.Fk);
                    myConnection.Open();
                    sqlCmd.ExecuteNonQuery();
                    myConnection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, "Insert Successfull");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Name");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No data to insert");
        }

        [HttpDelete]
        public HttpResponseMessage DeleteForeignData(int id)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Data Source=.;Initial Catalog=day3;Integrated Security=True";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from MainData where id=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Successfull");
        }

        [HttpPut]
        public HttpResponseMessage UpdateForeignData(int id, [FromBody] Foreign data)
        {
            if (data != null)
            {
                if (data.Name != "" || id > 1)
                {
                    SqlConnection myConnection = new SqlConnection();
                    myConnection.ConnectionString = @"Data Source=.;Initial Catalog=day3;Integrated Security=True";
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = "UPDATE MainData SET name = @name WHERE id=" + id + "";
                    sqlCmd.Connection = myConnection;

                    sqlCmd.Parameters.AddWithValue("@Name", data.Name);
                    myConnection.Open();
                    sqlCmd.ExecuteNonQuery();
                    myConnection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, "Update Successfull");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Name");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No data to insert");
        }
    }
}
