<%@ Page Title="" Language="C#" MasterPageFile="~/Teachar.Master" AutoEventWireup="true" CodeBehind="TForm2.aspx.cs" Inherits="ProComsys.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="margin:1%;"><br>
    <center><h3>แบบบันทึกการดำเนินงานโครงงานวิศวกรรมคอมพิวเตอร์ (CPE02)</h3></center><br>
    <div>
      รหัสโครงการ &nbsp;:&nbsp; <asp:Label ID="IDProject" runat="server" Text="IDProject" Width="416px"></asp:Label><br>
        <br>
      ชื่อโครงการ &nbsp;:&nbsp; &nbsp;<asp:Label ID="NProject" runat="server" Text="IDPROJECT" Width="416px"></asp:Label>
     </div>
     <div><br>

         <asp:GridView ID="GW1" runat="server" AutoGenerateColumns="False">
              <Columns>
                  
                   <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
               </asp:TemplateField>
              <%--   <asp:BoundField HeaderText="วันที่" DataField="dd" />--%>
                     <asp:BoundField HeaderText="วันที่" DataField="date" />
                 <asp:BoundField HeaderText="ประเด็น/หัวข้อ/งานที่มอบหมาย" DataField="topic" />
                 <asp:BoundField HeaderText="ข้อสรุป/ความคืบหน้าของงาน" DataField="con" />
                 <asp:BoundField HeaderText="หมายเหตุ" DataField="note" />
             </Columns>
         </asp:GridView>
         <br />
         <br />
        </div>

     <div>
        <center>
          <asp:Button ID="Sent" runat="server"  class="btn btn-success" style="background-color:#1C9F34" Text="Accept" OnClick="Sent_Click"/>
          <asp:Button ID="cancel" runat="server"   class="btn btn-success" style="background-color:#1C9F34" Text="Refuse" OnClick="cancel_Click"/>
         </center>
        </div>
        </div>
</asp:Content>
