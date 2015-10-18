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
    public partial class WebForm18 : System.Web.UI.Page
    {
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Session["Name"].ToString();
            showProject();
            ShowTitleProject();
        }

        protected void showProject()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select  f.FName as form , CONVERT(VARCHAR, r.RequestDate, 121) as date , re.SName as status, CONVERT(VARCHAR , si.SignDate,121) as Adate ,r.IDRequest as idr" +
            "  from Request r join RequestStatus re on r.RStatus = re.SNo  join Form f on r.NOForm = f.NOForm join SProject s on r.IDProject = s.IDProject  " +
        "   join [Sign] si on r.IDRequest = si.IDRequest    where s.SID ='" + id + "'", con);
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
            SqlCommand cmd = new SqlCommand("select distinct v.PThaiName , v.PEngName " +
            " from View_Teacher v  join SProject s on v.IDProject = s.IDProject " +
            " where s.SID = '" + id + "' ", con);
            SqlDataReader reader1 = cmd.ExecuteReader();

            if (reader1.Read())
            {
                PName.Text = reader1[0].ToString() + "  (" + reader1[1].ToString() + ")";
            }

            reader1.Close();
            con.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IDform = "";
            GridViewRow row = GridView1.SelectedRow;
            Session["IDRE"] = row.Cells[1].Text;
            Session["Role"] = "show";

            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select f.NOForm from Form f where  f.FName ='" + row.Cells[2].Text + "'", con);
            SqlDataReader reader1 = cmd.ExecuteReader();

            if (reader1.Read())
            {
               IDform = reader1[0].ToString();
            }

            reader1.Close();
            con.Close();
            Response.Redirect("Form" + IDform + "Student.aspx");

        
        }
    }
}