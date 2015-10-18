<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="Form2Student.aspx.cs" Inherits="ProComsys.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="margin:1%;"><br>
    <center><h3>แบบบันทึกการดำเนินงานโครงงานวิศวกรรมคอมพิวเตอร์(CPE02)</h3></center>
         <asp:DropDownList ID="DDTName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDTName_SelectedIndexChanged">
         </asp:DropDownList>
         <br>
    <div>
      รหัสโครงงาน &nbsp;&nbsp; <asp:Label ID="IDproject" runat="server" Text="IDPROJECT"></asp:Label>
        <br>
      ชื่อโครงงาน &nbsp;&nbsp;<asp:Label ID="NProject" runat="server" Text="IDPROJECT"></asp:Label>
     </div>
     <div>
         <%String id = Session["Name"].ToString(); %>>
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="878px"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
             <Columns>
                   <asp:ButtonField CommandName="select" Text="delete" />
                   <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
               </asp:TemplateField>
                 <asp:BoundField HeaderText="วันที่" DataField="date" />
                 <asp:BoundField HeaderText="ประเด็น/หัวข้อ/งานที่มอบหมาย" DataField="topic" />
                 <asp:BoundField HeaderText="ข้อสรุป/ความคืบหน้าของงาน" DataField="con" />
                 <asp:BoundField HeaderText="หมายเหตุ" DataField="note" />
             </Columns>
         </asp:GridView>
        <div>
         &nbsp;<asp:Button ID="Button1" runat="server"   Text="Add" Width="45px" OnClick="Button1_Click" />
         &nbsp;&nbsp;&nbsp;&nbsp;
   
            
         <asp:TextBox ID="txtDate" runat="server" Width="71px" ReadOnly ="true" placeholder="วันที่"></asp:TextBox>
             <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageUrl="~/Image/calender.jpg" OnClick="ImageButton1_Click" Width="35px" />
                      <asp:TextBox ID="txtTopic" runat="server" Width="313px" placeholder="ประเด็น/หัวข้อ/งานที่รับมอบหมาย"></asp:TextBox>
         <asp:TextBox ID="txtCon" runat="server" Width="296px" placeholder="ข้อสรุป/ความคืบหน้าของโครงงาน"></asp:TextBox>
         <asp:TextBox ID="txtNote" runat="server" Width="69px" placeholder="หมายเหตุ"></asp:TextBox>
             <asp:Calendar ID="Calendar1" runat="server" TargetControlID ="txtDate" OnSelectionChanged="Calendar1_SelectionChanged" ></asp:Calendar>

             </div>
        </div>

     <div><be><br>
        <center>
          <%--  <%# Container.DataItemIndex + 1 %>--%>
          <asp:Button ID="Sent" runat="server"  class="btn btn-success" style="background-color:#1C9F34" Text="Save" OnClick="Sent_Click"/>

          <asp:Button ID="cancel" runat="server"   class="btn btn-success" style="background-color:#1C9F34" Text="Back" OnClick="cancel_Click"/>
         </center>
        </div>
        </div>
</asp:Content>
