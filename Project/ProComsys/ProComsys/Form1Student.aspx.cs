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
    public partial class WebForm7 : System.Web.UI.Page
    {
        string id;
        string FName;
        string LName;
        string ponts = null;
        string role;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Session["Name"].ToString();
            FName = Session["FName"].ToString();
            LName = Session["LName"].ToString();
            role = Session["Role"].ToString();
            CheckEdit();
            if (!IsPostBack)
            {
                ShowDD();
            }
            check();
        }

        protected void check()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string s = "";
            SqlCommand cmd = new SqlCommand(" SELECT * FROM SProject WHERE SID = '" + Session["Name"].ToString() + "' order by IDProject", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               s = reader["IDProject"].ToString();
            }
            con.Close();
            con.Open();
            
            if (s != "")
            {
                SqlCommand cmd1 = new SqlCommand(" select  p.PEngName,p.PThaiName  from Project p  where p.IDProject = "+s, con);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        
                        TextBox2.Text = reader1[0].ToString();
                        TextBox1.Text = reader1[1].ToString();
                    }
                }
                reader1.Close();
                con.Close();
                DDTName_(s);
                Session["IDP"] = s;
            }
            
        }

        protected void ShowEdit()
        {

            
        }

        protected void CheckEdit()
        {

            if (role == "show")
            {
                string idre = Session["IDRE"].ToString();
              
                string nn = "";

                string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();
                SqlCommand cmd = new SqlCommand(" select pr.IDProject " +
                " from Request re join Project pr on re.IDProject = pr.IDProject where re.IDRequest ='" + idre + "'", con);
                SqlDataReader reader1 = cmd.ExecuteReader();

                if (reader1.Read())
                {
                    nn = reader1[0].ToString();
                }

                reader1.Close();
                con.Close();
                DD1.Text = "None";
                DD2.Text = "None";
                DD3.Text = "None";
                DD1.Enabled = false;
                DD2.Enabled = false;
                DD3.Enabled = false;
                ShowDD();
                ShowEdit2(nn);

                cancel.Visible = false;
                Sent.Text = "Back";

                //ShowEdit();

            }
            else
            {
                String ch1 = null;
                string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                con.Open();
                SqlCommand cmd = new SqlCommand(" select COUNT(*) from SProject s  join Request re on s.IDProject = re.IDProject   "
                + "where s.SID ='" + id + "' and re.RStatus !='4' ", con);
                SqlDataReader reader1 = cmd.ExecuteReader();

                if (reader1.Read())
                {
                    ch1 = reader1[0].ToString();
                }

                reader1.Close();
                con.Close();


                if (ch1 == "0")
                {

                  
                    ponts = "1";
                    //   MessageBox.Show("pont = "+ponts);
                    //   ShowDD();
                    InputName();
                }
                else
                {

                    ponts = "0";
                    //    MessageBox.Show("pont = " + ponts);
                  
                    SID1.Enabled = false;
                    SID2.Enabled = true;
                    SID3.Enabled = true;
                    Sent.Text = "Edit";
                    cancel.Text = "Back";
                    //   ShowDD();
                    if (!IsPostBack)
                    {
                        ShowEdit();
                    }

                }
            }
        }

        protected void InputName()
        {
            string ch = null;
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand("select SID from Student "
            + " where Student.SID ='" + id + "'", con);
            SqlDataReader reader1 = cmd.ExecuteReader();

            if (reader1.Read())
            {
                SID1.Text = reader1[0].ToString();
            }

            reader1.Close();
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




        protected int CheckStudent(string id)
        {
            string ch = null;

            if (id != "")
            {
                if (CheckStudentHAS(id) == 1)
                {
                    if (CheckIDStudent(id) == 0)
                    {
                        string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                        SqlConnection con = new SqlConnection(constr);

                        con.Open();
                        SqlCommand cmd = new SqlCommand("select count(*) from   Student s join SProject p on s.SID = p.SID  " +
                                " where  s.SId= LTRIM('" + id + "')", con);
                        SqlDataReader reader1 = cmd.ExecuteReader();

                        if (reader1.Read())
                        {
                            ch = reader1[0].ToString();
                        }
                        reader1.Close();
                        con.Close();

                        if (ch == "0")
                        {
                            return 0;
                        }
                        else
                        {
                            MessageBox.Show(id + " มีโครงการแล้ว", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return 1;
                        }
                    }
                    else
                    {
                        MessageBox.Show(id + " คุณใส่รหัสนิสิตไม่ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 1;
                    }
                }
                else
                {
                    MessageBox.Show(id + " ไม่มีรหัสนี้ในฐานข้อมูล", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 1;
                }
            }
            else
            {
                return 2;
            }
        }

        protected int CheckIDStudent(string str)
        {
            if (str != "")
            {
                int s1 = str.Length;
                int count = 0;
                for (int i = 0; i < s1; i++)
                {
                    Decimal a = str[i];
                    if (a <= 57 && a >= 48)
                    {
                        count++;
                    }
                    else
                    {
                        return 1;//ผิด
                    }
                }
                if (count == 8)
                {
                    return 0; //ถูก
                }
                else
                {
                    return 1;//ผิด
                }
            }
            else
            {
                return 2;
            }


        }

        protected int CheckStudentHAS(string id)
        {
            string ch = null;

            if (id != "")
            {
                if (CheckIDStudent(id) == 0)
                {
                    string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);

                    con.Open();
                    SqlCommand cmd = new SqlCommand("select count(*) from Student st  where st.SID = '" + id + "'", con);
                    SqlDataReader reader1 = cmd.ExecuteReader();

                    if (reader1.Read())
                    {
                        ch = reader1[0].ToString();
                    }
                    reader1.Close();
                    con.Close();

                    if (ch == "0")
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;  //มี รหัสอยู่ในดาต้าเบส
                    }
                }
                else
                {
                    MessageBox.Show(id + " คุณใส่รหัสนิสิตไม่ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 3;
                }
            }
            else
            {
                return 2;
            }
        }

        protected void InsertSProject(string SsID)
        {

            if (SsID != "")
            {
                string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into SProject(IDProject,SID)  values((select COUNT(*) from Project),'" + SsID + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void InsertRequest()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(" insert into Request(IDRequest,IDProject,NOForm,RStatus,RequestDate) " +
             "  values((select count(*) from Request )+1 " +
             ",(select count(*) from Project),'1','1',( convert (date ,getdate()) ) )", con);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        protected void InsertSign()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into [Sign](IDRequest,SFirstName,SLastName,SignDate)  " +
            " values( (select count(*) from Request) ,'" + CutString(DD1.Text) + "' ,(select t.TLastName from Teacher t  where t.TFirstName = '" + CutString(DD1.Text) + "'),'')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void INsertProject()
        {
            string countProjj = "";
            string constr1 = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con1 = new SqlConnection(constr1);
            con1.Open();
            SqlCommand cmd11 = new SqlCommand("select COUNT(*) from Project ", con1);
            SqlDataReader reader = cmd11.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    countProjj = reader[0].ToString();
                }
            }
            reader.Close();
            con1.Close();

            if (countProjj != "0")
            {
                string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand(" insert into Project(IDProject,PThaiName,PEngName) " +
                "  values((select count(*) from Project)+1,'" + TextBox3.Text + "','" + TextBox4.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                SqlCommand cmd1 = new SqlCommand(" insert into Project(IDProject,PThaiName,PEngName) " +
                "  values(0,'null','null')", con);
                cmd1.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(" insert into Project(IDProject,PThaiName,PEngName) " +
                "  values((select count(*) from Project)+1,'" + TextBox3.Text + "','" + TextBox4.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void deleteProject()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(" delete from Project   where Project.PThaiName = LTRIM('" + TextBox3.Text + "')", con);
            cmd.ExecuteNonQuery();
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

        protected void insertTeacher()
        {

            InsertTRole(CutString(DD1.Text), 1);

            InsertTRole(CutString(DD2.Text), 2);

            InsertTRole(CutString(DD3.Text), 3);

        }

        protected void insertStudent()
        {
            InsertSProject(SID1.Text);
            InsertSProject(SID2.Text);
            InsertSProject(SID3.Text);
        }

        protected void Sent_click(object sender, EventArgs e)
        {

            //  MessageBox.Show(ponts);
            if (ponts == "1")
            {
                if (TextBox3.Text != "" && TextBox4.Text != "")
                {
                    if (DD1.Text != DD2.Text && DD1.Text != DD3.Text && DD2.Text != DD3.Text)
                    {
                        if (DD1.Text != "None")
                        {
                            if (DD3.Text != "None")
                            {
                                if (CheckStudent(SID1.Text) != 1 && CheckStudent(SID2.Text) != 1 && CheckStudent(SID3.Text) != 1)
                                {
                                    if (SID2.Text == "" && SID3.Text == "" || SID2.Text != SID3.Text)
                                    {
                                        if (SID1.Text != SID2.Text && SID1.Text != SID3.Text)
                                        {
                                            INsertProject();
                                            insertStudent();
                                            insertTeacher();
                                            InsertRequest();
                                            InsertSign();
                                            MessageBox.Show("ส่งแบบเสนอหัวข้อโครงงานแล้ว", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Response.Redirect("Sform.aspx");
                                        }
                                        else
                                        {
                                            MessageBox.Show("คุณใส่รหัสนิสิตซ้ำกัน", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("คุณใส่รหัสนิสิตซ้ำกัน", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("โปรดเลือกกรรมการ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("โปรดเลือกอาจารย์ที่ปรึกษา", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        MessageBox.Show("คุณเลือกอาจารย์ซ้ำ หรือไม่เป็นตามเงื่อนไข", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("คุณไม่ได้ใส่ชื่อโปรเจค", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (ponts == "0")
            {
                if (DD1.Text != DD2.Text && DD1.Text != DD3.Text && DD2.Text != DD3.Text)
                {
                    if (DD1.Text != "None")
                    {
                        if (DD3.Text != "None")
                        {

                            INsertProject();
                            insertStudent();
                            insertTeacher();
                            InsertRequest();
                            InsertSign();

                            /*string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
                            SqlConnection con = new SqlConnection(constr);
                            con.Open();
                            SqlCommand cmd5 = new SqlCommand(" UPDATE [User] SET PThaiName= '" + TName.Text + "',PEngName='" + EName.Text + "'  WHERE username = " + Session["IDP"] + " ", con);
                            cmd5.ExecuteNonQuery();
                  */
        //ชื่อโครงงาน,รหัสโครงงาน
                            MessageBox.Show("แก้ไข แบบเสนอหัวข้อโครงงานแล้ว", "finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Response.Redirect("Sform.aspx");
                        }
                        else
                        {
                            MessageBox.Show("โปรดเลือกกรรมการ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("โปรดเลือกอาจารย์ที่ปรึกษา", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("คุณเลือกอาจารย์ซ้ำ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Response.Redirect("SHistory.aspx");
            }


        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sform.aspx");
        }

        protected void DDTName_(string s)
        {

              
                DD1.Text = "None";
                DD2.Text = "None";
                DD3.Text = "None";

                ShowEdit2(s);
        }

        protected void ShowEdit2(string idp)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();


            //show all sid 
            SqlCommand cmd2 = new SqlCommand("select distinct v.SID  from view_cpe01 v  " +
            " where v.IDProject = '" + idp + "'", con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.HasRows)
            {
                int count = 0;
                String[] sids = { "", "", "" };
                while (reader2.Read())
                {
                    sids[count] = reader2[0].ToString();
                    count++;
                }

                SID1.Text = sids[0].ToString();
                SID2.Text = sids[1].ToString();
                SID3.Text = sids[2].ToString();

            }
            reader2.Close();

            con.Close();
            con.Open();
            SqlCommand cmd3 = new SqlCommand("select te.TFirstName ,te.TLastName  " +
          " from TProject tp join TRole tr on tp.NO = tr.No  join Role ro on tr.RID = ro.RID join Teacher te on te.TID = tr.TID " +
          " where tp.IDProject ='" + idp + "' and tr.RID ='1'", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            
            if (reader3.Read())
            {
                DD1.Text = reader3[0].ToString() + " " + reader3[1].ToString();

            }
            reader3.Close();


            


            string constr1 = WebConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            SqlConnection con1 = new SqlConnection(constr1);
            con1.Open();
            SqlCommand cmd4 = new SqlCommand("select te.TFirstName ,te.TLastName  " +
            " from TProject tp join TRole tr on tp.NO = tr.No  join Role ro on tr.RID = ro.RID join Teacher te on te.TID = tr.TID " +
            " where tp.IDProject ='" + idp + "' and tr.RID ='2'", con1);
            SqlDataReader reader4 = cmd4.ExecuteReader();
            if (reader4.HasRows)
            {
                while (reader4.Read())
                {
                    DD2.Text = reader4[0].ToString() + " " + reader4[1].ToString();
                }
            }
            reader4.Close();


            SqlCommand cmd5 = new SqlCommand("select te.TFirstName ,te.TLastName  " +
            " from TProject tp join TRole tr on tp.NO = tr.No  join Role ro on tr.RID = ro.RID join Teacher te on te.TID = tr.TID " +
            " where tp.IDProject ='" + idp + "' and tr.RID ='3'", con1);
            SqlDataReader reader5 = cmd5.ExecuteReader();
            if (reader5.HasRows)
            {
                while (reader5.Read())
                {
                    DD3.Text = reader5[0].ToString() + " " + reader5[1].ToString();
                }
            }
            reader5.Close();
            con1.Close();

        }


    }

}