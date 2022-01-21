using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class DbConnection
    {
        public DbConnection()
        {
        }
        // Code below allows us to connect Database 
        public SqlConnection Connect()
        {
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-TIRV6AC ;Database=Test;Trusted_Connection=True;Connect Timeout =30;MultipleActiveResultSets=True;");
            connect.Open();
            return connect;

        }
    }
}
