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
    public partial class WebForm3 : System.Web.UI.Page
    {
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {

            id = Session["Name"].ToString();
            ShowTitleProject();
            showProject();
            showNoData();
        }

        protected void showNoData()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();


            string cou = "";
            SqlCommand cmd1 = new SqlCommand("select  count(*) " +
            "  from Request r join RequestStatus re on r.RStatus = re.SNo  join Form f on r.NOForm = f.NOForm join SProject s on r.IDProject = s.IDProject  " +
        "   join [Sign] si on r.IDRequest = si.IDRequest    where s.SID ='" + id + "' and re.SNo ='1'", con);
            SqlDataReader reader = cmd1.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cou = reader[0].ToString();
                }
            }
            reader.Close();
            con.Close();

            if (cou == "0")
            {
                NoRequest.Visible = true;
            }
            else
            {
                NoRequest.Visible = false;
            }
        }

        protected void showProject() 
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select  f.FName as form , CONVERT(VARCHAR, r.RequestDate, 103) as date , re.SName as status, si.SignDate as Adate ,r.IDRequest as idr" +
            "  from Request r join RequestStatus re on r.RStatus = re.SNo  join Form f on r.NOForm = f.NOForm join SProject s on r.IDProject = s.IDProject  "+
        "   join [Sign] si on r.IDRequest = si.IDRequest    where s.SID ='" + id + "' and re.SNo ='1'", con);
            SqlDataReader reader2 = cmd.ExecuteReader();
            GridView1.DataSource = reader2;
            GridView1.DataBind();

            reader2.Close();
            con.Close();
        }

        protected void ShowTitleProject()
        {
            
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct v.PThaiName , v.PEngName "+
            " from View_Teacher v  join SProject s on v.IDProject = s.IDProject "+
            " where s.SID = '"+id+"' ", con);
            SqlDataReader reader1 = cmd.ExecuteReader();

            if (reader1.Read())
            {
                labp.Text = reader1[0].ToString()+"  ("+reader1[1].ToString()+")";
            }

            reader1.Close();
            con.Close();

            if (labp.Text == "Label")
            {
                labp.Visible = false;
                OUT.Visible = false;
            }
            else 
            {
                labp.Visible = true;
                OUT.Visible = true;
            }
        }

        protected void OUT_Click(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from SProject  where SProject.SID = '"+id+"'", con);
            cmd.ExecuteNonQuery();
            con.Close();


            labp.Visible = true;
            OUT.Visible = true;
            Response.Redirect("SIndex.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = GridView1.SelectedRow;
            String key = row.Cells[2].Text;  // IDRequest
            string countAcceptStatus = "";

            string constr1 = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con1 = new SqlConnection(constr1);

            con1.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from Request re  "+
            " where re.RStatus ='2' and re.IDRequest = '" + key + "' or   re.RStatus ='4' and re.IDRequest = '" + key + "'", con1);
            SqlDataReader reader1 = cmd.ExecuteReader();

            if (reader1.Read())
            {
                countAcceptStatus = reader1[0].ToString() ;
            }

            reader1.Close();
            con1.Close();

   
            if (countAcceptStatus == "0") // checl ว่าลบได้หรือเปล่า
            {
                string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                //search data is form 1 ?
                string chForm = "";
                string idpro = "";

                SqlCommand cmd2 = new SqlCommand("  select re.NOForm ,re.IDProject from SProject sp join Request re on sp.IDProject = re.IDProject  " +
                " where re.IDRequest = '" + key + "'", con);
                SqlDataReader reader2 = cmd2.ExecuteReader();

                    if (reader2.Read())
                    {
                        chForm = reader2[0].ToString();
                        idpro = reader2[1].ToString();
                    }
                reader2.Close();
              
                if (chForm == "1")
                {
                    // delete data in Request table
                    SqlCommand cmd3 = new SqlCommand("delete from SProject where IDProject ='" + idpro + "'", con);
                    cmd3.ExecuteNonQuery();
                }

               // delete data in Request table
                SqlCommand cmd1 = new SqlCommand("update Request  set IDProject = 0  where IDRequest = '" + key + "'", con);
                cmd1.ExecuteNonQuery();

                con.Close();
              

                MessageBox.Show("ลบเสร็จสิ้น", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Response.Redirect("SIndex.aspx");
            }
            else 
            {
                MessageBox.Show("ไม่สามารถลบได้","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        
    }
}