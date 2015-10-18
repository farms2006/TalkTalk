<%@ Page Title="" Language="C#" MasterPageFile="~/Teachar.Master" AutoEventWireup="true" CodeBehind="TForm1.aspx.cs" Inherits="ProComsys.WebForm16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            width: 247px;
             font-weight: bold;
         }
         .auto-style2 {
             text-decoration: underline;
         }
         .auto-style3 {
             font-weight: bold;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="margin:1%;"><br>
    <center><h3>แบบเสนอหัวข้อโครงงานวิศวกรรมคอมพิวเตอร์ (CPE01)</h3></center><br>
    <div>
      <h5 class="auto-style2">  <strong>ชื่อโครงการ</strong></h5>
  
            <strong>ภาษาไทย&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>:&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="TName" runat="server" Text="Label" Width="416px"></asp:Label>
        <br />
        <br>
            <strong>ภาษาอังกฤษ</strong>&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;  <asp:Label ID="EName" runat="server" Text="Label" Width="421px"></asp:Label>
     </div>
     <div><br>
        <h5 class="auto-style2"><strong>รายชื่อนิสิตผู้ทำโครงการ</strong></h5>
    <table class="table table-bordered">
        <tr>
            <td ><b>ที่</b></td>
            <td class="auto-style3">ชื่อ-นามสกุล</td>
            <td class="auto-style3">รหัสนิสิต</td>
            <td class="auto-style3">เบอร์โทร</td>
            <td><b>อีเมล์</b></td>
        </tr>
        <tr>
            <td>1</td>
            <td class="auto-style9"><asp:Label ID="NName1" runat="server" Text="Label" Width="216px"></asp:Label></td> 
            <td class="auto-style10"><asp:Label ID="SID1" runat="server" Text="Label" Width="142px"></asp:Label></td>
            <td class="auto-style11"><asp:Label ID="Phone1" runat="server" Text="Label" Width="158px"></asp:Label></td>
            <td><asp:Label ID="Em1" runat="server" Text="Label" Width="203px"></asp:Label></td>
        </tr>
          <tr>
            <td>2</td>
            <td class="auto-style9"><asp:Label ID="NName2" runat="server" Text="Label" Width="216px"></asp:Label></td> 
            <td class="auto-style10"><asp:Label ID="SID2" runat="server" Text="Label" Width="142px"></asp:Label></td>
            <td class="auto-style11"><asp:Label ID="Phone2" runat="server" Text="Label" Width="158px"></asp:Label></td>
            <td><asp:Label ID="Em2" runat="server" Text="Label" Width="203px"></asp:Label></td>
        </tr>
          <tr>
            <td>3</td>
           <td class="auto-style9"><asp:Label ID="NName3" runat="server" Text="Label" Width="216px"></asp:Label></td> 
            <td class="auto-style10"><asp:Label ID="SID3" runat="server" Text="Label" Width="142px"></asp:Label></td>
            <td class="auto-style11"><asp:Label ID="Phone3" runat="server" Text="Label" Width="158px"></asp:Label></td>
            <td><asp:Label ID="Em3" runat="server" Text="Label" Width="203px"></asp:Label></td>
        </tr>
        </table>
        </div>

     <div>
        <h5 class="auto-style2"><strong>อาจารย์ที่ปรึกษาและกรรมการ</strong></h5>
    <table class="table table-bordered">
        <tr>
            <td class="auto-style1">อาจารย์ที่ปรึกษา</td>
            <td class="auto-style3">อาจารย์ที่ปรึกษาร่วม(ถ้ามี)</td>
            <td><b>เสนอรายชื่อกรรมการ 1 ท่าน</b></td>
        </tr>
        <tr>
            
             <td class="auto-style9"><asp:Label ID="Ad1" runat="server" Width="216px"></asp:Label></td> 
            <td class="auto-style10"><asp:Label ID="Ad2" runat="server" Width="142px"></asp:Label></td>
            <td class="auto-style11"><asp:Label ID="Cm" runat="server" Width="158px"></asp:Label></td>
        </tr>
        </table>
       
       
        <center>
          <asp:Button ID="submit" runat="server"  class="btn btn-success" style="background-color:#1C9F34" Text="Accept" OnClick="submit_Click" />
          <asp:Button ID="cancel" runat="server"   class="btn btn-success" style="background-color:#1C9F34" Text="Refuse" OnClick="cancel_Click" />
         </center>
        </div>
        </div>
</asp:Content>
