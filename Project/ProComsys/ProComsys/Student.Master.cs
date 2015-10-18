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
    public partial class Student : System.Web.UI.MasterPage
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
            string Sname = null;
            try
            {
                string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();
                SqlCommand cmd = new SqlCommand("select s.SFirstName , s.SLastName  from Student s  "+
                    "    where s.sid = LTRIM(' " +id+"')" , con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Sname = reader[0].ToString()+" "+reader[1].ToString()+"          ";
                    Session["FName"] = reader[0].ToString();
                    Session["LNAme"] = reader[1].ToString();

                }

                reader.Close();
                con.Close();
            }
            catch (Exception)
            {

            }
            SNAME.Text = Sname;
        }

        protected void About_Click(object sender, EventArgs e)
        {
            Response.Redirect("SAbout.aspx");
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("SIndex.aspx?id="+id);
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainINDEX.aspx");
        }

        protected void form_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sform.aspx");
        }

        protected void logout_Click1(object sender, EventArgs e)
        {
            Response.Redirect("MainINDEX.aspx");
        }
    }
}