<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="SIndex.aspx.cs" Inherits="ProComsys.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div style="margin-left:5%; width:80%;"><br>
       <center>
   <div>
      
     <h4>   <asp:Label ID="labp" runat="server" Text="Label"></asp:Label></h4><br>   
       <center><h3><asp:Label ID="NoRequest" runat="server" Text="ไม่มีคำร้องขอที่รอการตอบรับ"></asp:Label></h3></center>
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
           <Columns>
                <asp:ButtonField Text="delete" CommandName="select" />
                <asp:TemplateField HeaderText="ลำดับที่">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
               </asp:TemplateField>
                <asp:BoundField DataField="idr" HeaderText="คำขอร้องที่" />
               <asp:BoundField DataField="form" HeaderText="ฟอร์ม" />
               <asp:BoundField DataField="date" HeaderText="วันที่ส่ง" />
               <asp:BoundField DataField="status" HeaderText="สถานะ" />
                <asp:BoundField DataField="Adate" HeaderText="วันที่ตอบรับ" NullDisplayText="-" />
           </Columns>
       </asp:GridView>
     
       <br />
     
       </div>

           <asp:Button ID="OUT"  class="btn btn-success" style="background-color:#1C9F34" runat="server" Text="ออกจากกลุ่ม" OnClick="OUT_Click" />

  </center>
    </div>

</asp:Content>
