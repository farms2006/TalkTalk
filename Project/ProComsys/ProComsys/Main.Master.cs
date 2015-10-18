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
    public partial class Mas : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainINDEX.aspx");
        }

        protected void About_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainAbout.aspx");
        }

      

        protected void login_Click1(object sender, EventArgs e)
        {
            Session["Name"] = IDName.Value;
            string ID = IDName.Value;
            string Password = Pass.Value;
            string count1 = null;
            try
            {
                string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from   Student   " +
                     " where  Student.SId= LTRIM(" + ID + ")  and Student.SPass= LTRIM(" + Password + ") ", con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    count1 = reader[0].ToString();

                }

                reader.Close();
                con.Close();
            }
            catch (Exception)
            {

            }
            if (count1 == "1")
            {
                Response.Redirect("SIndex.aspx");
            }
            else
            {
                count1 = null;
                try
                {
                    string constr2 = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                    SqlConnection con1 = new SqlConnection(constr2);

                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("select count(*) from  Teacher a	 " +
                         " where a.TFirstName=LTRIM( '" + ID + "' )  and a.TPass= LTRIM('" + Password + "') ", con1);
                    SqlDataReader reader1 = cmd1.ExecuteReader();

                    if (reader1.Read())
                    {
                        count1 = reader1[0].ToString();

                    }

                    reader1.Close();
                    con1.Close();
                }
                catch (Exception)
                {
                }
                if (count1 == "1")
                {
                    Response.Redirect("TIndex.aspx");
                }
                else
                {
                    MessageBox.Show("No Account");
                    Response.Redirect("MainINDEX.aspx");
                }
            }
        }
    }
}