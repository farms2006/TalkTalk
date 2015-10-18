using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProComsys
{
    public partial class WebForm24 : System.Web.UI.Page
    {
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Session["Name"].ToString();
            showData();
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

        protected void showData()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select  distinct sh.NOForm as CPE , sh.Form as form , CONVERT(VARCHAR, sh.RequestDate, 103) as Date , sh.StatusRequest as status ,pr.PThaiName as PName , sh.IDRequest as IDRequest" +
            " from ShowAllform sh join Project pr on sh.IDProject = pr.IDProject   " +
            " where sh.SignFName ='" + CutString(id) + "'  and sh.StatusRequest !='รอตอบรับ' ", con);
            SqlDataReader reader2 = cmd.ExecuteReader();
            GridView1.DataSource = reader2;
            GridView1.DataBind();

            reader2.Close();
            con.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string pro = row.Cells[2].Text;
            Session["Project"] = row.Cells[4].Text;
            Session["IDRe"] = row.Cells[1].Text;
            Session["Role"] = "show";
            Response.Redirect("TForm" + pro + ".aspx");
        }

    }
}