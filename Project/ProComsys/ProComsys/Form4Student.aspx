<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="Form4Student.aspx.cs" Inherits="ProComsys.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="margin:1%;"><br>
    <center><h3>แบบประเมินข้อเสนอโครงงานวิศวกรรมคอมพิวเตอร์(CPE04)</h3></center><br><br>

        
    
        <center>
             <div>
             ส่งแบบประเมินข้อเสนอโครงงาน
             </div><br>
          <asp:Button ID="Sent" runat="server"  class="btn btn-success" style="background-color:#1C9F34" Text="Sent"/>
          <asp:Button ID="cancel" runat="server"   class="btn btn-success" style="background-color:#1C9F34" Text="Cancel"/>
         </center>
        </div>
      
</asp:Content>
