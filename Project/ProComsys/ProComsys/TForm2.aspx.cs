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
    public partial class WebForm17 : System.Web.UI.Page
    {
        string project;
        string IDRequest;
        string role;
        protected void Page_Load(object sender, EventArgs e)
        {
            project = Session["Project"].ToString();   //project name
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
            SqlCommand cmd = new SqlCommand("select  pr.IDProject , pr.PEngName from Project pr where pr.PThaiName = '" + project + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    IDProject.Text = reader[0].ToString();
                    NProject.Text = project + "  (" + reader[1].ToString() + ")";
                }
            }
            reader.Close();

            SqlCommand cmd2 = new SqlCommand("select cp.Topic as topic , cp.Conclude  as con, cp.Note as note , cp.Date as date " +
            " from  Request re join  CPE2 cp on cp.IDRequest = re.IDRequest  join Project pr on re.IDProject = pr.IDProject  " +
            " where pr.PThaiName =LTRIM('" + project + "')", con);

            SqlDataReader reader2 = cmd2.ExecuteReader();
            GW1.DataSource = reader2;
            GW1.DataBind();
            reader2.Close();
            con.Close();



        }

        protected void Sent_Click(object sender, EventArgs e)
        {
            if (role != "show")
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show("คุณเลือกให้ผ่านใช่ไหม", "INFORMATION", buttons);

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

