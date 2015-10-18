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
    public partial class WebForm9 : System.Web.UI.Page
    {
        string id;
        string idpro;
        string role;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Session["Name"].ToString();
            role = Session["Role"].ToString();
            Showtitle();
            showGrid();
          
            if (!IsPostBack)
            {
                ShowDDProject();
                Calendar1.Visible = false;
            }
            if (role == "show") 
            {
                Button1.Visible = false; //หายไป
                txtDate.Visible = false;
                txtCon.Visible = false;
                txtNote.Visible = false;
                txtTopic.Visible = false;
                ImageButton1.Visible = false;
                cancel.Visible = false;
                Sent.Text = "Back";
            }
        }

        protected void ShowDDProject()
        {
            string count = "";
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from  SProject s join Request re on s.IDProject = re.IDProject   where s.SID ='" + id + "'  and re.NOForm='2'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    count = reader[0].ToString();
                }
            }
            reader.Close();
            con.Close();

            if (count == "0")
            {
                DDTName.Visible = false;
            }
            else
            {
                Sent.Text = "Edit";
                string constr1 = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                SqlConnection con1 = new SqlConnection(constr1);

                con1.Open();
                SqlCommand cmd1 = new SqlCommand("select re.IDRequest , pr.IDProject  from  SProject s join Request re on s.IDProject = re.IDProject join Project pr on pr.IDProject = re.IDProject " +
                "  where s.SID ='" + id + "'  and re.NOForm='2'", con1);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.HasRows)
                {
                    ListItem item1 = new ListItem();
                    item1.Value = "เลือก";
                    DDTName.Items.Add(item1);
                    int ct = 1;
                    while (reader1.Read())
                    {
                        ListItem item = new ListItem();
                        item.Value = reader1[0].ToString() + "  #" + reader1[1].ToString() ;
                        DDTName.Items.Add(item);
                        ct++;
                    }


                }
                reader1.Close();
                con1.Close();
            }
        }

        protected void Showtitle()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct   v.IDProject,v.PThaiName,v.PEngName " +
                "  from View_Teacher v  join SProject s on v.IDProject = s.IDProject "+
                "  where s.SID = '"+id+"' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    IDproject.Text = reader[0].ToString();
                    idpro = reader[0].ToString();
                    NProject.Text = reader[1].ToString() + " (" + reader[2].ToString()+")";
                }
            }
            reader.Close();
            con.Close();
        }

        protected void showGrid()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select c.Topic as topic, c.Conclude  as con,c.Note  as note,convert(varchar, c.Date,101)  as date  "+
        " from (Request re join  CPE2 c on re.IDRequest = c.IDRequest join Project p on re.IDProject = p.IDProject) join SProject s on p.IDProject = s.IDProject  " +
                " where s.SID ='" + id + "'   order by  c.Date    ", con);
            SqlDataReader reader2 = cmd.ExecuteReader();
            GridView1.DataSource = reader2;
            GridView1.DataBind();

            reader2.Close();
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
            if (txtNote.Text == "") 
            {
                txtNote.Text = "-";
            }
            try
            {
                if (txtDate.Text != "" && txtCon.Text != "" && txtTopic.Text != "")
                {
                    string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CPE2(IDRequest,Topic,Conclude,Note,Date)   " +
                    " values((select re.IDRequest from  SProject s join Request re on s.IDProject = re.IDProject   where s.SID ='" + id + "' and re.RStatus ='2' and re.NOForm='1')," +
                    " '" + txtTopic.Text + "','" + txtCon.Text + "','" + txtNote.Text + "','"+txtDate.Text+"')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("Form2Student.aspx");
                }
                else
                {
                    MessageBox.Show("ข้อมูลไม่ครบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) 
            {
                //MessageBox.Show(ex.Message);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible == false)
            {
                Calendar1.Visible = true;
            }
            else
            {
                Calendar1.Visible = false;
            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtDate.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            Calendar1.Visible = false;
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
     //       string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
     //       SqlConnection con = new SqlConnection(constr);
     //       con.Open();
     //       SqlCommand cmd = new SqlCommand("delete CPE2 "+
     //" from  Request re join SProject sp on re.IDProject = sp.IDProject join CPE2 cp on cp.IDProject = sp.IDProject "+
     //" where sp.SID = '"+id+"'", con);
     //       cmd.ExecuteNonQuery();
     //       con.Close();
            Response.Redirect("sform.aspx");
        }

     

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (role == "show") 
            {
                MessageBox.Show("ไม่สามารถดำเนินการได้", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GridViewRow row = GridView1.SelectedRow;
                String key = row.Cells[2].Text;
                try
                {
                    string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete CPE2  where convert(varchar,CPE2.Date,101) = '" + key + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("Form2Student.aspx");
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
            }

        }

        protected void InsertSign()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into [Sign](IDRequest,SFirstName,SLastName,SignDate)  " +
     " values( (select count(*) from Request) ,(select distinct te.TFirstName from Teacher te join TRole tr  on te.TID = tr.TID  join TProject tp on tp.NO = tr.No " +
     "  join Request re on tp.IDProject = re.IDProject where tp.IDProject ='"+idpro+"'  and tr.RID = '1') ,"+
     "(select distinct te.TLastName from Teacher te join TRole tr  on te.TID = tr.TID  join TProject tp on tp.NO = tr.No " +
     "  join Request re on tp.IDProject = re.IDProject where tp.IDProject ='" + idpro + "'  and tr.RID = '1') ,'')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void Sent_Click(object sender, EventArgs e)
        {
            if (role == "show") 
            {
                Response.Redirect("SHistory.aspx");
            }
            else
            {
                string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand(" insert into Request(IDRequest,IDProject,NOForm,RStatus,RequestDate)" +
                " values((select COUNT(*) from Request )+1,'" + idpro + "','2','1', ( convert (date ,getdate()) ) )", con);
                cmd.ExecuteNonQuery();


                SqlCommand cmd1 = new SqlCommand(" update CPE2  set IDRequest = (select count(*) from Request) "+
                " where IDRequest = (select re.IDRequest from  SProject s join Request re on s.IDProject = re.IDProject   where s.SID ='"+id+"' and re.RStatus ='2' and re.NOForm='1')", con);
                cmd1.ExecuteNonQuery();
                con.Close();

                InsertSign();
                MessageBox.Show("ส่งแบบบันทึกการดำเนินงานโครงงานแล้ว", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Response.Redirect("Sform.aspx");
            }
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

        protected void DDTName_SelectedIndexChanged(object sender, EventArgs e)
        {

            showGridEdit(CutString(DDTName.Text));
            Response.Redirect("Form2Student.aspx");
            
        }

        protected void showGridEdit(string idre)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select c.Topic as topic, c.Conclude  as con,c.Note  as note,convert(varchar, c.Date,101)  as date  " +
        " from (Request re join  CPE2 c on re.IDRequest = c.IDRequest join Project p on re.IDProject = p.IDProject) join SProject s on p.IDProject = s.IDProject  " +
                " where s.SID ='" + id + "'   and re.IDRequest ='"+idre+"'   order by  c.Date    ", con);
            SqlDataReader reader2 = cmd.ExecuteReader();
            GridView1.DataSource = reader2;
            GridView1.DataBind();

            reader2.Close();
            con.Close();
        }
    }
}