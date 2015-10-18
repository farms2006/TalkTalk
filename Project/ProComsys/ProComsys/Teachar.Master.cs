using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ProComsys
{
    public partial class Teachar : System.Web.UI.MasterPage
    {
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                id = Session["Name"].ToString();
                NameLOGIN(id);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void NameLOGIN(string Name)
        {

            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select te.TLastName from Teacher te  where te.TFirstName ='"+id+"' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                SNAME.Text = id+"  "+reader[0].ToString();
            }
            reader.Close();
            con.Close();
           
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            //Response.Redirect("SIndex.aspx?id=" + id);
        }

        protected void About_Click(object sender, EventArgs e)
        {
            //Response.Redirect("SAbout.aspx");
        }

        protected void logout_Click1(object sender, EventArgs e)
        {
           // Session["Name"].close;
            Response.Redirect("MainINDEX.aspx");
        }

    }
}