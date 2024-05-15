using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


namespace AdvisorTable
{
    public partial class addAdvisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            
            string advisorName = txtAdvName.Text.ToString();
            string officeNumber = txtOffNum.Text.ToString();
            string phoneNumber = txtPhoNum.Text.ToString();

            string connString = ConfigurationManager.ConnectionStrings["ITD210_08ConnectionString"].ConnectionString;
            SqlConnection conn = null;
            conn= new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert into [Advisor](advisorName,officeNumber, phoneNumber) Values('" + advisorName + "','" + officeNumber + "','" + phoneNumber +"')";

            cmd.Connection = conn;
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 1)
            { 
                lbl1.Text = "WOOHOO WE DID IT";
            }
            else
            {
                lbl1.Text = "NO GOOD";
            }
            conn.Close();
        }
    }
}