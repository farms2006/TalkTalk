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
    public partial class WebForm10 : System.Web.UI.Page
    {
        string id;
        string idpro;
        string pont="";
        string role; 
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Session["Name"].ToString();
            role = Session["Role"].ToString();
            Showtitle();
            CheckEdit();
            if (!IsPostBack)
            {
                ShowDD();
            }

           
        }

        protected void CheckEdit()
        {
            if (role == "show")
            {
                DD2.Enabled = false;
                DD1.Enabled = false;
                DataForm.Enabled = false;
                DD3.Enabled = false;
                pont = "1";
                cancel.Visible = false;
                Sent.Text = "Back";
                ShowEdit2(idpro);
            }
            else
            {
                String ch1 = null;
                string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();
                SqlCommand cmd = new SqlCommand(" select count(*) from SProject sp join  Request re on sp.IDProject = re.IDProject  join CPE3 cp on cp.IDRequest = re.IDRequest " +
                " where sp.SID ='" + id + "' and  re.RStatus != '4' ", con);
                SqlDataReader reader1 = cmd.ExecuteReader();

                if (reader1.Read())
                {
                    ch1 = reader1[0].ToString();
                }

                reader1.Close();
                con.Close();


                if (ch1 == "0")
                {
                    pont = "0";
                  
                }
                else
                {
                
                    DD2.Enabled = false;
                    DD1.Enabled = false;
                    DataForm.Enabled = false;
                    DD3.Enabled = false;
                    pont = "1";
                    cancel.Visible = false;
                    Sent.Text = "Back";
                    ShowEdit2(idpro);
                }
            }
        }

        protected void ShowEdit2(string idp)
        {
            ShowDD();
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd3 = new SqlCommand("select distinct te.TFirstName , te.TLastName  " +
          " from TProject tp join TRole tr on tp.NO = tr.No  join Role ro on tr.RID = ro.RID join Teacher te on te.TID = tr.TID " +
          " join SProject sp on sp.IDProject = tp.IDProject  where tp.IDProject ='" + idp + "' and tr.RID ='4'", con);
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



            SqlCommand cmd = new SqlCommand("select cp.Problem   from Project pr join Request re on pr.IDProject = pr.IDProject join CPE3 cp on cp.IDRequest = re.IDRequest  where pr.IDProject ='"+idp+"' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataForm.Text = reader[0].ToString();
                }
            }
            reader.Close();
            con.Close();
        }


        protected void Showtitle()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct   v.IDProject,v.PThaiName,v.PEngName " +
                "  from View_Teacher v  join SProject s on v.IDProject = s.IDProject " +
                "  where s.SID = '" + id + "' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    IDproject.Text = reader[0].ToString();
                    idpro = reader[0].ToString();
                    NProject.Text = reader[1].ToString() + " (" + reader[2].ToString() + ")";
                }
            }
            reader.Close();

            con.Close();
        }

        protected void ShowDD()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select a.TFirstName, a.TLastName  from Teacher a  ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                ListItem item1 = new ListItem();
                item1.Value = "None";
                DD1.Items.Add(item1);
                while (reader.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = reader[0].ToString() + " " + reader[1].ToString();
                    DD1.Items.Add(item);
                }


            }
            reader.Close();

            SqlCommand cmd1 = new SqlCommand("select a.TFirstName, a.TLastName  from Teacher a  ", con);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.HasRows)
            {
                ListItem item1 = new ListItem();
                item1.Value = "None";
                DD2.Items.Add(item1);
                while (reader1.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = reader1[0].ToString() + " " + reader1[1].ToString();
                    DD2.Items.Add(item);
                }


            }
            reader1.Close();

            SqlCommand cmd3 = new SqlCommand("select a.TFirstName, a.TLastName  from Teacher a  ", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            if (reader3.HasRows)
            {
                ListItem item1 = new ListItem();
                item1.Value = "None";
                DD3.Items.Add(item1);
                while (reader3.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = reader3[0].ToString() + " " + reader3[1].ToString();
                    DD3.Items.Add(item);
                }


            }
            reader.Close();
            con.Close();
        }


        protected void InsertTRole(string Name, int role)
        {
            if (Name != "None")
            {
                string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into TRole(No,TID,RID) values ((select COUNT(*) from TRole)+1,(select t.TID from Teacher t  where t.TFirstName = RTRIM('" + Name + "')),'" + role + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();

                INsertTProject();
            }
        }

        protected void INsertTProject()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(" insert into TProject(IDProject,NO)" +
            " values((select count(*) from Project),(select COUNT(*) from TRole))", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void InsertRequest()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(" insert into Request(IDRequest,IDProject,NOForm,RStatus,RequestDate) " +
    "  values((select count(*) from Request )+1 " +
        ",(  select  distinct  re.IDProject from SProject sp  join Request re on sp.IDProject = re.IDProject " +
            "  where sp.SID = '"+id+"' and re.NOForm = '1'),'3','1',( convert (date ,getdate()) ) )", con);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        protected void InsertCPE3() 
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("  insert into CPE3(IDRequest,Problem) "+
        "   values((select count(*) from Request ) ,('"+DataForm.Text+"' ))", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void InsertSign(string name)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into [Sign](IDRequest,SFirstName,SLastName,SignDate)  " +
     " values( (select count(*) from Request) ,'" + name + "' ,(select t.TLastName from Teacher t  where t.TFirstName = '" + name + "'),'')", con);
            cmd.ExecuteNonQuery();
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

        protected void Sent_Click(object sender, EventArgs e)
        {
            if (role == "show") 
            {
                Response.Redirect("SHistory.aspx");
            }
            else
            {
                if (pont == "0")
                {

                    if (DD1.Text != "None" && DD2.Text != "None" && DD3.Text != "None")
                    {
                        if (DD1.Text != DD2.Text && DD1.Text != DD3.Text && DD2.Text != DD3.Text)
                        {
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result;

                            result = MessageBox.Show("ยืนยัน", "INFORMATION", buttons);

                            if (result == DialogResult.Yes)
                            {
                                InsertTRole(CutString(DD1.Text), 4);
                                InsertTRole(CutString(DD2.Text), 4);
                                InsertTRole(CutString(DD3.Text), 4);

                                InsertRequest();
                                InsertSign(CutString(DD1.Text));
                                InsertRequest();
                                InsertSign(CutString(DD2.Text));
                                InsertRequest();
                                InsertSign(CutString(DD3.Text));
                                InsertCPE3();

                                MessageBox.Show("ส่งแบบฟอร์มขอสอบข้อเสนอโครงงานแล้ว", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Response.Redirect("Sform.aspx");

                            }
                        }
                        else
                        {
                            MessageBox.Show("คุณเลือกกรรมการสอบโครงงานซ้ำ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("โปรดเลือกกรรมการสอบโครงงาน", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {

                    Response.Redirect("Sform.aspx");
                }
            }
  
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sform.aspx");
        }
    }
}