using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Registration 
{
  public class Registration_Class
  {
        private SqlConnection Obj_Conn = new SqlConnection();
        private SqlCommand Cmd = new SqlCommand();
        private SqlDataReader Reader_Login;
        string QueryString;
        
        Public Registration_Class()
        {
          //Add connection String
          String Conn = @""; 
           Obj_Conn.ConnectionString = ConnString;
        }
        
        public string Registration(string UserName, string Email, string Password)
        {
          //Insert into user details
        }
        
  }
  
}
