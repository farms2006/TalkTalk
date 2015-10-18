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
    public partial class WebForm19 : System.Web.UI.Page
    {
        string projectName;
        string IDRequest;
        string role;
        protected void Page_Load(object sender, EventArgs e)
        {
            projectName = Session["Project"].ToString();   //project name
            IDRequest = Session["IDRe"].ToString();
            role = Session["Role"].ToString();

            if (role == "show")
            {
                Sent.Text = "Back";
                cancel.Visible = false;
            }
            ShowForm();
        }

        protected void ShowForm()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select  pr.IDProject , pr.PEngName, pr.IDProject from Project pr where pr.PThaiName = '" + projectName + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    IDproject.Text = reader[2].ToString();
                    NProject.Text = projectName + "  (" + reader[1].ToString() + ")";
                }
            }
            reader.Close();

            SqlCommand cmd3 = new SqlCommand("select distinct  v.TFirstName ,v.TLastName  from view_cpe01 v "+
            " where v.RID  = '4' and v.PThaiName = '" + projectName + "'" , con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            if (reader3.HasRows)
            {

                int count = 0;
                String[] sids = { "", "", "" };
                while (reader3.Read())
                {
                    sids[count] = reader3[0].ToString() + " " + reader3[1].ToString();
                    count++;
                }
                DD1.Text = sids[0].ToString();
                DD2.Text = sids[1].ToString();
                DD3.Text = sids[2].ToString();
            }
            reader3.Close();

            SqlCommand cmd1 = new SqlCommand("select cp.Problem from CPE3 cp join Request re on cp.IDRequest = re.IDRequest join Project pr on pr.IDProject = re.IDProject "+
            " where pr.PThaiName = '"+projectName+"'", con);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    DataForm.Text = reader1[0].ToString();
                }
            }
            reader1.Close();
            con.Close();
        }

     

        protected void Sent_Click(object sender, EventArgs e)
        {
            if (role != "show")
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show("คุณเลือก 'ผ่าน' ใช่ไหม", "INFORMATION", buttons);

                if (result == DialogResult.Yes)
                {
                    string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Request  set  RStatus ='2'  from Request re  where re.IDRequest ='" + IDRequest + "'", con);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand(" update Sign  set  SignDate =  convert (date ,getdate())  from Sign re  where re.IDRequest ='" + IDRequest + "'", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    Response.Redirect("TProjectAdviser.aspx");
                }
            }
            else 
            {
                Response.Redirect("THistory.aspx");
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show("คุณเลือก 'ไม่ผ่าน' ใช่ไหม", "INFORMATION", buttons);

            if (result == DialogResult.Yes)
            {
                string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Request  set  RStatus ='4'  from Request re  where re.IDRequest ='" + IDRequest + "'", con);
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand(" update Sign  set  SignDate =  convert (date ,getdate())  from Sign re  where re.IDRequest ='" + IDRequest + "'", con);
                cmd1.ExecuteNonQuery();
                con.Close();

                Response.Redirect("TProjectAdviser.aspx");
            }
        }
    }
}