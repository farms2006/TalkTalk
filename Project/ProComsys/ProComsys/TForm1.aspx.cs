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
    public partial class WebForm16 : System.Web.UI.Page
    {
        string project;
        string id;
        string idpro;
        string role;
        protected void Page_Load(object sender, EventArgs e)
        {
            project = Session["Project"].ToString();
            id = Session["Name"].ToString();
            role = Session["Role"].ToString();
            if (role == "show")
            {
                submit.Text = "Back";
                cancel.Visible = false;
            }
            ShowForm();
        }

        protected string CutString(string str)
        {
            int s1 = str.Length;
            string str2 = "";
            for (int i = 0; i < s1; i++)
            {
                if (str[i] != ' ')
                {
                    str2 = str2 + str[i];
                }
                else
                {
                    break;
                }
            }

            return str2;
        }

        protected void ShowForm() 
        {
            TName.Text = project;

            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select  distinct v.PEngName , v.IDRequest   from  view_cpe01 v  where v.PThaiName = LTRIM('" + project + "')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    EName.Text = reader[0].ToString();
                    idpro = reader[1].ToString();
                }
            }
            reader.Close();


            SqlCommand cmd2 = new SqlCommand("select distinct v.SID,v.SFirstName ,v.SLastName,v.SPhone,v.SEmail   from view_cpe01 v " +
            "  where v.PThaiName = '"+project+"'", con);
            SqlDataReader reader1 = cmd2.ExecuteReader();
            if (reader1.HasRows)
            {
                int count = 0;
                String[] sids = { "","",""};
                String[] Namee = { "","",""};
                String[] Phonee = { "","",""};
                String[] Email = { "","",""};
                while (reader1.Read())
                {
                    sids[count] = reader1[0].ToString();
                    Namee[count] = reader1[1].ToString()+" "+reader1[2].ToString();
                    Phonee[count] = "0"+reader1[3].ToString();
                    Email[count] = reader1[4].ToString();

                    count++;
                }

                SID1.Text = sids[0].ToString();
                SID2.Text = sids[1].ToString();
                SID3.Text = sids[2].ToString();
                NName1.Text = Namee[0].ToString();
                NName2.Text = Namee[1].ToString();
                NName3.Text = Namee[2].ToString();
                Phone1.Text = Phonee[0].ToString();
                Phone2.Text = Phonee[1].ToString();
                Phone3.Text = Phonee[2].ToString();
                Em1.Text = Email[0].ToString();
                Em2.Text = Email[1].ToString();
                Em3.Text = Email[2].ToString(); 
            }
            reader1.Close();


            SqlCommand cmd3 = new SqlCommand("select distinct v.TFirstName ,v.TLastName  from view_cpe01 v "+
            " where v.PThaiName = '"+project+"' and v.RID ='1'", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            string aa1= "";
            if (reader3.HasRows)
            {
               
                while (reader3.Read())
                {
                   aa1 = reader3[0].ToString() + " " + reader3[1].ToString();
                }
            }
            reader3.Close();
            Ad1.Text = aa1;

            SqlCommand cmd4 = new SqlCommand("select distinct v.TFirstName ,v.TLastName  from view_cpe01 v " +
        " where v.PThaiName = '" + project + "' and v.RID ='2'", con);
            SqlDataReader reader4 = cmd4.ExecuteReader();
            if (reader4.HasRows)
            {
                while (reader4.Read())
                {
                    Ad2.Text = reader4[0].ToString() + " " + reader4[1].ToString();
                }
            }
            reader4.Close();

            SqlCommand cmd5 = new SqlCommand("select distinct v.TFirstName ,v.TLastName  from view_cpe01 v " +
        " where v.PThaiName = '" + project + "' and v.RID ='3'", con);
            SqlDataReader reader5 = cmd5.ExecuteReader();
            if (reader5.HasRows)
            {
                while (reader5.Read())
                {
                    Cm.Text = reader5[0].ToString() + " " + reader5[1].ToString();
                }
            }
            reader5.Close();
            con.Close();


        }

        protected void submit_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("update Request  set  RStatus ='2'  from Request re  where re.IDRequest ='" + idpro + "'", con);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand(" update Sign  set  SignDate =  convert (date ,getdate())  from Sign re  where re.IDRequest ='" + idpro + "'", con);
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
            SqlCommand cmd = new SqlCommand("update Request  set  RStatus ='4'  from Request re  where re.IDRequest ='" + idpro + "'", con);
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand(" update Sign  set  SignDate =  convert (date ,getdate())  from Sign re  where re.IDRequest ='" + idpro + "'", con);
            cmd1.ExecuteNonQuery();
            con.Close();
            Response.Redirect("TProjectAdviser.aspx");
        }
    }
}