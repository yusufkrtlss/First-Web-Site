using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class CustomerPage : System.Web.UI.Page
    {
        DbConnection connection = new DbConnection();
        // We came here with QueryString from WebForm1. This is the Second Page.
        protected void Page_Load(object sender, EventArgs e)
        {
            string aa = Request.QueryString["EmployeeID"]; // This is the QueryString
            SqlConnection conn = connection.Connect();
            // code below , this code allows us to see all the details of an employee using Parameters
            SqlCommand sqlCommand = new SqlCommand("select FirstName,LastName,Age,Gender from EmployeeDemographics where EmployeeID = @ID", conn); 
            sqlCommand.Parameters.AddWithValue("@ID",aa );
            SqlDataReader reader = sqlCommand.ExecuteReader();

            Repeater1.DataSource = reader;
            Repeater1.DataBind();
            // code below allows us to see detail of an employee using reader.
            while (reader.Read())
            {
                Label1.Text = reader["FirstName"].ToString()+ " "+ reader["LastName"].ToString()+" "+reader["Age"].ToString()+" "+reader["Gender"].ToString();
            }
            conn.Close();
        } 
    }
}