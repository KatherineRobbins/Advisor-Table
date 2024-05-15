using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AdvisorTable
{
    public partial class deleteAdvisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string connString = ConfigurationManager.ConnectionStrings["ITD210_08ConnectionString"].ConnectionString;
                SqlConnection conn = null;
                conn = new SqlConnection(connString);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                string query1 = "Select [advisorID],[advisorName] From Advisor";

                SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);


                if (ds.Tables[0].Rows.Count != 0)
                {
                    CheckBoxList1.DataSource = ds;
                    CheckBoxList1.DataTextField = "advisorID";
                    CheckBoxList1.DataValueField = "advisorID";

                    CheckBoxList1.DataBind();
                }
                else
                {

                }
                conn.Close();
            }
        }
    
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["ITD210_08ConnectionString"].ConnectionString;
            SqlConnection conn = null;
            conn = new SqlConnection(connString);
            conn.Open();

            string advID = "";

            for(int i = 0; i<CheckBoxList1.Items.Count; i++) 
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    advID = CheckBoxList1.Items[i].Value;
                }
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete From [Advisor] where advisorID = ' " + advID + "'";
            cmd.Connection = conn;
            int rowAffected = cmd.ExecuteNonQuery();

            if (rowAffected == 1)
            {
                lbl1.Text = "WHOOHOO";
            }
            else
            {
                lbl1.Text = "NOTHING DELETED";
            }
        }

    protected void btnLookup_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["ITD210_08ConnectionString"].ConnectionString;
            SqlConnection conn = null;
            string advID = "";
            conn = new SqlConnection(connString);
            conn.Open();

            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    advID = CheckBoxList1.Items[i].Value;
                }
                
            }
            
            string query = "Select * From [Advisor] where advisorID = ' " + advID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                txtAdvId.Text = reader[0].ToString();
                txtAdvName.Text = reader[1].ToString();
                txtOffNum.Text = reader[2].ToString();
                txtPhoNum.Text = reader[3].ToString();

            }
        }
           

    
            protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string advisorID = txtAdvId.Text.ToString();
            string advisorName = txtAdvName.Text.ToString();
            string officeNumber = txtOffNum.Text.ToString();
            string phoneNumber = txtPhoNum.Text.ToString();

            string connString = ConfigurationManager.ConnectionStrings["ITD210_08ConnectionString"].ConnectionString;
            SqlConnection conn = null;
            conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update [Advisor] SET advisorName = '" + advisorName + "',  officeNumber = '" + officeNumber + "', phoneNumber = '" + phoneNumber + "' WHERE advisorID = '" + advisorID + "'";
            

            cmd.Connection = conn;
            int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 1)
                    {
                         lbl1.Text = "This advisor's record is updated";
                    }
                else
                  {
                     lbl1.Text = "Record Not Found!";
                   }
                conn.Close();

         }
        

           
        
    }
}