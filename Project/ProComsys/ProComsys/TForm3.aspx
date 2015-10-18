<%@ Page Title="" Language="C#" MasterPageFile="~/Teachar.Master" AutoEventWireup="true" CodeBehind="TForm3.aspx.cs" Inherits="ProComsys.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
        }
        .auto-style2 {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="margin:1%;"><br>
    <center><h3>แบบขอสอบข้อเสนอโครงงานวิศวกรรมคอมพิวเตอร์ (CPE03)</h3></center><span class="auto-style1"><strong>โครงงาน</strong></span><br>
     <div>
      รหัสโครงงาน &nbsp;:&nbsp; <asp:Label ID="IDproject" runat="server" Text="IDPROJECT"></asp:Label>
         <br />
        <br>
      ชื่อโครงงาน &nbsp; :&nbsp; &nbsp;<asp:Label ID="NProject" runat="server" Text="IDPROJECT"></asp:Label>
     </div>


     <div>
        <h5 class="auto-style1"><strong>ประเด็นปัญหาและขอบเขตของโครงงานโดยย่อ</strong></h5>
         <asp:TextBox ID="DataForm"  runat="server" Height="190px" Width="817px" Enabled="False" TextMode="MultiLine"></asp:TextBox>

          <div>
        <h5 class="auto-style1"><strong>กรรมการสอบโครงงาน</strong></h5>
    <table class="table table-bordered">
        <tr>
            <td class="auto-style2">กรรมการคนที่ 1</td>
            <td class="auto-style2">กรรมการคนที่ 2</td>
            <td class="auto-style2">กรรมการคนที่ 3</td>
        </tr>
        <tr>
              <td class="auto-style1"><asp:Label ID="DD1" runat="server" Text="Ad1" Enabled="False"></asp:Label></td>
             <td class="auto-style1"><asp:Label ID="DD2" runat="server" Text="Ad2" Enabled="False"></asp:Label></td>
            <td class="auto-style1"><asp:Label ID="DD3" runat="server" Text="commit"></asp:Label></td>
        </tr>
        </table>
       
       <br>
        <center>
          <asp:Button ID="Sent" runat="server"  class="btn btn-success" style="background-color:#1C9F34" Text="Accept" OnClick="Sent_Click"/>
          <asp:Button ID="cancel" runat="server"   class="btn btn-success" style="background-color:#1C9F34" Text="Refuse" OnClick="cancel_Click"/>
         </center>
        </div>
        </div>
</asp:Content>
