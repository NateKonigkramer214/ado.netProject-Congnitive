using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Audio_Box_2._0
{
    //Class used to register people for app and add there info to db
    public class Registration_Class
    {
        //represents connection to databse 
        private SqlConnection Obj_Conn = new SqlConnection();
        private SqlCommand Cmd = new SqlCommand();
        //private SqlDataReader Reader_Login;
        string QueryString;
        public Registration_Class()
        {
            //Connection string to my Database 
            string ConnString = @"Data Source=NATHANLAPTOP\MSSQLSERVER01;Initial Catalog=AudioBox;Integrated Security=True";
            Obj_Conn.ConnectionString = ConnString;
        }
        public string Registration(string Username, string Email, string Password)
        {
            //Using try: Means that we put code we want to excute and if an exception is found it will move and excute the catch statment
            try
            {
                //Clears and refreshes all parameters 
                Cmd.Parameters.Clear();
                Cmd.Connection = Obj_Conn;
                //Insert query that will insert userdata for registration
                QueryString = "Insert into UserDetails(Username,Email, Password) Values(@Username, @Email, @Password)";
                //Add method that takes a String and an Object.
                // AddWithValue (string parameterName, object value);
                Cmd.Parameters.AddWithValue("@Username", Username); 
                Cmd.Parameters.AddWithValue("@Email", Email);
                Cmd.Parameters.AddWithValue("@Password", Password);
                Cmd.CommandText = QueryString;
                //connection opened
                Obj_Conn.Open();
                // Executed query
                Cmd.ExecuteNonQuery();
                //Returns Message once user has registerd
                return "User registered Successfully continue to login";
            }
            //Excuted when exception is found. 
            catch (Exception ex)
            {
                // show error Message
                return ex.Message;
            }
            finally
            {
                // close connection
                if (Obj_Conn != null)
                {
                    Obj_Conn.Close();
                }
            }


        }

    }
}
