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
    public partial class WebForm5 : System.Web.UI.Page
    {
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {

            id = Session["Name"].ToString();
            if (!IsPostBack)
            {
                ShowDD();
            }
        }

        protected void ShowDD()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select ro.RName  from Role ro ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                ListItem item1 = new ListItem();
                item1.Value = "None";
                DropDownList1.Items.Add(item1);
                while (reader.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = reader[0].ToString() ;
                    DropDownList1.Items.Add(item);
                }
            }
            reader.Close();
            con.Close();
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string role = DropDownList1.Text;
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select pr.PThaiName as PTName , pr.PEngName  as PEName , pr.IDProject  as  IDPro"+
        " from Teacher te join TRole tr on te.TID = tr.TID join Role ro on ro.RID = tr.RID join TProject tp on tp.NO = tr.No join Project pr on pr.IDProject = tp.IDProject "+
        " where ro.RName ='"+role+"' and te.TFirstName ='"+CutString(id)+"' ", con);
            SqlDataReader reader2 = cmd.ExecuteReader();
            GridView1.DataSource = reader2;
            GridView1.DataBind();

            reader2.Close();
            con.Close();

            GridView2.DataSource = null;
            GridView2.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
         
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select fo.FName as form, req.SName  as status, re.IDRequest as IDRe , si.SignDate   as AcceptDate ,convert(varchar, re.RequestDate,121)    as RequestDate  " +
            "   from Project pr join Request re on re.IDProject = pr.IDProject join Form fo on fo.NOForm = re.NOForm join RequestStatus req on req.SNo = re.RStatus join sign si on re.IDRequest = si.IDRequest" +
            "   where pr.IDProject ='"+row.Cells[1].Text+"'", con);
            SqlDataReader reader2 = cmd.ExecuteReader();
            GridView2.DataSource = reader2;
            GridView2.DataBind();

            reader2.Close();
            con.Close();
        }
    }
}