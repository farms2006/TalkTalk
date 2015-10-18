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
    public partial class WebForm6 : System.Web.UI.Page
    {
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Session["Name"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Role"] = "See";
            Response.Redirect("Form1Student.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string count = null;

            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct COUNT(*) " +
               "  from View_Teacher v  join SProject s on v.IDProject = s.IDProject  " +
                "  where  v.NOForm = '1' and v.RStatus = '2' and s.SID = '" + id + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                count = reader[0].ToString();

            }

            reader.Close();
            con.Close();

            if (count == "0")
            {
                MessageBox.Show("ยังไม่ผ่าน เงื่อนไข ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Session["Role"] = "See";
                Response.Redirect("Form2Student.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string count = null;

            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct COUNT(*) " +
               "  from View_Teacher v  join SProject s on v.IDProject = s.IDProject  " +
                "  where  v.NOForm = '1' and v.RStatus = '2' and s.SID = '" + id + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                count = reader[0].ToString();

            }

            reader.Close();
            con.Close();

            if (count == "0")
            {
                MessageBox.Show("ยังไม่ผ่าน เงื่อนไข ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Session["Role"] = "See";
                Response.Redirect("Form3Student.aspx");
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string count = null;

            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct COUNT(*) " +
               "  from View_Teacher v  join SProject s on v.IDProject = s.IDProject  " +
                "  where  v.NOForm = '3' and v.RStatus = '2' and s.SID = '" + id + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                count = reader[0].ToString();

            }

            reader.Close();
            con.Close();

            if (count == "0")
            {
                MessageBox.Show("ยังไม่ผ่าน เงื่อนไข ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Session["Role"] = "See";
                Response.Redirect("Form4Student.aspx");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string count = null;

            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct COUNT(*) " +
               "  from View_Teacher v  join SProject s on v.IDProject = s.IDProject  " +
                "  where  v.NOForm = '4' and v.RStatus = '2' and s.SID = '" + id + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                count = reader[0].ToString();

            }

            reader.Close();
            con.Close();

            if (count == "0")
            {
                MessageBox.Show("ยังไม่ผ่าน เงื่อนไข ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Session["Role"] = "See";
                Response.Redirect("Form5Student.aspx");
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string count = null;

            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct COUNT(*) " +
               "  from View_Teacher v  join SProject s on v.IDProject = s.IDProject  " +
                "  where  v.NOForm = '5' and v.RStatus = '2' and s.SID = '" + id + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                count = reader[0].ToString();

            }

            reader.Close();
            con.Close();

            if (count == "0")
            {
                MessageBox.Show("ยังไม่ผ่าน เงื่อนไข ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Session["Role"] = "See";
                Response.Redirect("Form6Student.aspx");
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string count = null;

            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct COUNT(*) " +
               "  from View_Teacher v  join SProject s on v.IDProject = s.IDProject  " +
                "  where  v.NOForm = '7' and v.RStatus = '2' and s.SID = '" + id + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                count = reader[0].ToString();

            }

            reader.Close();
            con.Close();

            if (count == "0")
            {
                MessageBox.Show("ยังไม่ผ่าน เงื่อนไข ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Session["Role"] = "See";
                Response.Redirect("Form7Student.aspx");
            }
        }
    }
}