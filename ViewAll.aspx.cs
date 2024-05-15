using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace AdvisorTable
{
    public partial class ViewAll : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ITD210_08ConnectionString"].ToString();
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select* from [Advisor]";
                cmd.Connection = con;

                SqlDataReader rd = cmd.ExecuteReader();

                table.Append("<table border = '2'>");
                table.Append("<tr><th>Advisor ID</th><th>Advisor Name</th><th>Office Number</th><th>Phone Number</th>");

                if(rd.HasRows)
                {
                    while(rd.Read())
                    {
                        table.Append("<tr>");
                        table.Append("<td>" + rd[0] + "</td>");
                        table.Append("<td>" + rd[1] + "</td>");
                        table.Append("<td>" + rd[2] + "</td>");
                        table.Append("<td>" + rd[3] + "</td>");
                        table.Append("</tr>");
                    }
                }
                table.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
                rd.Close();
                con.Close();   
            }//closes if postback
        }
    }
}