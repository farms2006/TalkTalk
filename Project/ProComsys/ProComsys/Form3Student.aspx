<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="Form3Student.aspx.cs" Inherits="ProComsys.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="margin:1%;"><br>
    <center><h3>แบบขอสอบข้อเสนอโครงงานวิศวกรรมคอมพิวเตอร์(CPE03)</h3></center><span class="auto-style1"><strong>โครงงาน</strong></span><br>
     <div>
      รหัสโครงงาน &nbsp;:&nbsp; <asp:Label ID="IDproject" runat="server" Text="IDPROJECT"></asp:Label>
        <br>
      ชื่อโครงงาน &nbsp;&nbsp; : &nbsp;<asp:Label ID="NProject" runat="server" Text="IDPROJECT"></asp:Label>
     </div>


     <div>
        <h5 class="auto-style1"><strong>ประเด็นปัญหาและขอบเขตของโครงงานโดยย่อ</strong></h5>
         <div class ="hard_break">
         <asp:TextBox ID="DataForm"  runat="server" Height="190px" Width="817px" TextMode="MultiLine"></asp:TextBox>
             </div>
          <div>
        <h5 class="auto-style1"><strong>กรรมการสอบโครงงาน</strong></h5>
    <table class="table table-bordered">
        <tr>
            <td class="auto-style1">กรรมการคนที่ 1</td>
            <td class="auto-style13">กรรมการคนที่ 2</td>
            <td>กรรมการคนที่ 3</td>
        </tr>
        <tr>
              <td class="auto-style1"><asp:DropDownList ID="DD1" runat="server" Width="203px" placeholder="เลือกอาจารย์" AutoPostBack="True"></asp:DropDownList></td>
             <td class="auto-style1"><asp:DropDownList ID="DD2" runat="server" Width="203px" placeholder="เลือกอาจารย์" AutoPostBack="True"></asp:DropDownList></td>
             <td class="auto-style1"><asp:DropDownList ID="DD3" runat="server" Width="203px" placeholder="เลือกอาจารย์" AutoPostBack="True"></asp:DropDownList></td>   
        </tr>
        </table>
       
       <br>
        <center>
          <asp:Button ID="Sent" runat="server"  class="btn btn-success" style="background-color:#1C9F34" Text="Sent" OnClick="Sent_Click"/>
          <asp:Button ID="cancel" runat="server"   class="btn btn-success" style="background-color:#1C9F34" Text="Cancel" OnClick="cancel_Click"/>
         </center>
        </div>
        </div>
</asp:Content>
