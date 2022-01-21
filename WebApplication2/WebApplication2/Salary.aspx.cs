using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Salary : System.Web.UI.Page
    {
        DbConnection connection = new DbConnection();
        // This is the main page of Changing Salary of Jobs.
        protected void Page_Load(object sender, EventArgs e)
        {
            AddingSalary();
        }
        // Adding salary function allows us to SHOW Department Name on the main page and send department ids to sql, Also We are using DropDown.
        public void AddingSalary()
        {
            SqlConnection conn = connection.Connect();
            string query = "select DepartmentID , DepartmentName from Salaries join Department on Salaries.DepartmentID = Department.ID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SalaryDropDown.DataSource = cmd.ExecuteReader();
                SalaryDropDown.DataTextField = "DepartmentName";
                SalaryDropDown.DataValueField = "DepartmentID";
                SalaryDropDown.DataBind();
            }
            conn.Close();
        }
        // Button1_Click allows us to call AddNewSalary Function.
        protected void Button1_Click(object sender, EventArgs e)
        {
            AddNewSalary();
        }
        // This AddNewSalary function allows us to update new salary if exist, if not insert current salary. 
        public void AddNewSalary()
        {
            SqlConnection conn = connection.Connect();
            string query = "if exists(SELECT * from Salaries where DepartmentID=@DEPID) BEGIN update Salaries set Salaries = @SAL where DepartmentID = @DEPID   End else begin insert into Salaries values(@DROPDOWN, @TEXT)   end ";
            using(SqlCommand cmd = new SqlCommand (query, conn))
            {

                cmd.Parameters.AddWithValue("@DEPID", Convert.ToInt32(SalaryDropDown.SelectedItem.Value));
                cmd.Parameters.AddWithValue("@SAL", TextBox1.Text);
                cmd.Parameters.AddWithValue("@DROPDOWN", Convert.ToInt32(SalaryDropDown.SelectedItem.Value));
                cmd.Parameters.AddWithValue("@TEXT", Convert.ToInt32(SalaryDropDown.SelectedItem.Value));
                cmd.ExecuteNonQuery();
                Label1.Text += "Salary Added or Updated Department " + SalaryDropDown.SelectedItem.Text;
              
                
            }
        }
    }
}