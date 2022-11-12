using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;

namespace wpf
{
    public class Sqlclass
    {
       private string connectionString = "Data Source=NIHAD; Initial Catalog=Userpassword; Integrated Security=SSPI";
        SqlConnection sqlConnection = null;
       public Sqlclass()
        {
             sqlConnection = new SqlConnection(connectionString);
        }
        public bool Check(string UserName,string password)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM Authors WHERE Id = @id OR FirstName = @UserName", conn);
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = UserName;
                SqlDataReader reader = cmd.ExecuteReader();
                return reader.FieldCount != 0;
            }
        }
        public bool AddUser(string UserName, string password)
        {
            try
            {
                sqlConnection.Open();
                string insertString = $@"INSERT INTO User (User, Password) VALUES('{UserName}', '{password}')";
                SqlCommand cmd = new(insertString, sqlConnection);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch { return false; }
            finally
            {
                if (sqlConnection != null) sqlConnection.Close();
            }
        }

    }
}
