<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="Sform.aspx.cs" Inherits="ProComsys.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 47px;
        }
        .auto-style3 {
            width: 627px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="margin-left:5%; width:80%;"><br>
   <table  class="table table-hover" >
       <tr>
           <td class="auto-style2">
               <h4>เอกสาร</h4>
               </td>
           <td class="auto-style3">
           <h4>ชื่อเอกสาร</h4>
               </td>
           <td>
          <%--     <h4>สถานะ</h4>--%>
               </td>
       </tr>
       <tr>
           <td class="auto-style2">CPE01
               </td>
           <td class="auto-style3">
             
                   <asp:Button ID="Button1" runat="server" Text=" แบบเสนอหัวข้อโครงงานวิศวกรรมคอมพิวเตอร์" OnClick="Button1_Click" Width="606px" />
 
               </td>
           <td></td>
           </tr>
       <tr>
            <td class="auto-style2">CPE02
               </td>
           <td class="auto-style3">
              <asp:Button ID="Button2" runat="server" Text="  แบบบันทึกการดำเนินงารโครงงานวิศวกรรมคอมพิวเตอร์" OnClick="Button2_Click" Width="606px" />

               </td>
             <td></td>
           </tr>
       <tr>
            <td class="auto-style2">CPE03
               </td>
           <td class="auto-style3">
                 <asp:Button ID="Button3" runat="server" Text="  แบบขอสอบข้อเสนอโครงงานวิศวกรรมคอมพิวเตอร์" OnClick="Button3_Click" Width="606px" />
               </td>
             <td></td>
           </tr>
        <tr>
            <td class="auto-style2">CPE04
               </td>
            <td class="auto-style3">
               <asp:Button ID="Button4" runat="server" Text="  แบบประเมินข้อเสนอโครงงานวิศวกรรมคอมพิวเตอร์" OnClick="Button4_Click" Width="606px" />


               </td>
              <td></td>
           </tr>
        <tr>
             <td class="auto-style2">CPE05
               </td>
            <td class="auto-style3">
                <asp:Button ID="Button5" runat="server" Text="   แบบประเมินความก้าวหน้าโครงงานวิศวกรรมคอมพิวเตอร์" OnClick="Button5_Click" Width="606px" />

         
               </td>
              <td></td>
           </tr>
        <tr>
             <td class="auto-style2">CPE06
               </td>
            <td class="auto-style3">
              <asp:Button ID="Button6" runat="server" Text="    แบบขอสอบโครงงานวิศวกรรมคอมพิวเตอร์" OnClick="Button6_Click" Width="606px" />

         
               </td>
              <td></td>
           </tr>
       <tr>
            <td class="auto-style2">CPE07
               </td>
           <td class="auto-style3">
                <asp:Button ID="Button7" runat="server" Text="     แบบขอสอบโครงงานวิศวกรรมคอมพิวเตอร์" OnClick="Button7_Click" Width="606px" />

        
               </td>
             <td></td>
           </tr>
       </table>
    </div>

</asp:Content>
