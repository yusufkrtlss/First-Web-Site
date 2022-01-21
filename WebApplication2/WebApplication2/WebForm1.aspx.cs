using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        // Object frrom DbConnection
        DbConnection connection = new DbConnection();
        // Main Page
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
            DIdropdown();
            GetAll2();
        }
        // It allows us to SHOW department names on the main page and send department ids to sql, Also We are using DropDown.
        public void DIdropdown()
        {
            SqlConnection conn = connection.Connect();
            string query = "Select ID , DepartmentName from Department";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                DIDropDown.DataSource = cmd.ExecuteReader();
                DIDropDown.DataTextField = "DepartmentName";
                DIDropDown.DataValueField = "ID";
                DIDropDown.DataBind();
            }
            conn.Close();
        }
        // button1.click allow us to ADD a new person in the EmployeeDemographics using Parameters
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.Connect();
            string aa = null;
            Label1.Text = "A Person ";
            string query = "IF NOT EXISTS(SELECT * FROM EmployeeDemographics WHERE TcNo= @TN2) BEGIN insert into EmployeeDemographics(FirstName, LastName, Age, Gender, DepartmentID, TcNo) values(@FN, @LN, @AG, @GN, @DI, @TN) SELECT SCOPE_IDENTITY() as editid END ";
            using (SqlCommand sqlCommand = new SqlCommand(query, conn))
            {
                sqlCommand.Parameters.AddWithValue("@FN", TextBox2.Text);
                sqlCommand.Parameters.AddWithValue("@LN", TextBox3.Text);
                sqlCommand.Parameters.AddWithValue("@AG", TextBox4.Text);
                sqlCommand.Parameters.AddWithValue("@GN", GenderDropdown.SelectedItem.Text);
                sqlCommand.Parameters.AddWithValue("@DI",Convert.ToInt32(DIDropDown.SelectedItem.Value));
                sqlCommand.Parameters.AddWithValue("@TN", TextBox5.Text);
                sqlCommand.Parameters.AddWithValue("@TN2", TextBox5.Text);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    aa = reader["editid"].ToString();
                }
                Label1.Text += "Employee Added";
                GetAll();
            }
            if (aa == null)
            {
                Label2.Text = "Data not added";
            }
            else
            {
                Label2.Text = "Data added";
            }

            conn.Close();

        }
        // Button2_Click allow us to DELETE a person in the EmployeeDemographics using Parameters
        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.Connect();

            SqlCommand sqlCommand = new SqlCommand("delete from EmployeeDemographics where EmployeeID = @ID", conn);
            sqlCommand.Parameters.AddWithValue("@ID", TextBox1.Text);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            Label1.Text += "Employee Deleted";
            GetAll();
            conn.Close();

        }
        // GetALL function allow us to SEE ALL DATA from EmployeeDemographics using Repeater
        public void GetAll()
        {
            SqlConnection conn = connection.Connect();
            // buraya joinli kodu yaz  departmen adıkten sonra tamamdır zamanın kalırsa kodların her birine açıklamalrı yap mutlaka kalmazsa yarn devam edersin açıklamalara
            SqlCommand sqlCommand = new SqlCommand("Select * from EmployeeDemographics join Salaries on EmployeeDemographics.DepartmentID = Salaries.DepartmentID", conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            
            Repeater1.DataSource = reader;
            Repeater1.DataBind();
            

            

            conn.Close();
        }
        // TGetAll2 function allow us to SEE ALL DATA from Department using Repeater
        public void GetAll2()
        {
            SqlConnection conn = connection.Connect();
            SqlCommand sqlCommand = new SqlCommand("Select * from Department", conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            Repeater2.DataSource = reader;
            Repeater2.DataBind();


            conn.Close();
        }


        /*SqlConnection baglanti = connection.baglan();
        SqlCommand com = new SqlCommand("UPDATE Product_Category_Mapping SET CategoryId=@CI,IsFeaturedProduct=@IP where ProductId=@PI and DisplayOrder=@DO", baglanti);
        com.Parameters.AddWithValue("@PI", x);
                                com.Parameters.AddWithValue("@CI", kategoriID);
                                com.Parameters.AddWithValue("@IP", false);
                                com.Parameters.AddWithValue("@DO", 1);
                                com.ExecuteNonQuery();
                                baglanti.Close();*/
    }
}