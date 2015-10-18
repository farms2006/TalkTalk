<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="SHistory.aspx.cs" Inherits="ProComsys.WebForm18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>  <div style="margin:1%;"><br>
          
        <h4>  <asp:Label ID="PName" runat="server" Text="คุณไม่มีประวัติเอกสาร"></asp:Label></h4>
  
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
           <Columns>
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
                <asp:ButtonField Text="รายละเอียด" CommandName="select" HeaderText="เพิ่มเติม" />
           </Columns>
       </asp:GridView>
     
          </div>
    </center>
</asp:Content>
