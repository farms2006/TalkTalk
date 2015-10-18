<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProComsys.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div style="margin:1%;">  

       <center>  <br><br><br>
              <div id='div1' style="width:40%;border:5px solid #6F6;">
                  <div style="margin:1%">
        <h2 style="margin:10px;">       
         <center> LOGIN</center></h2>
             <form class="form-inline ;">
                <div class="form-group ; ">
                     <label style="float:left;">ID</label>
                      <input type="text" class="form-control" id="IDName" placeholder="012345" runat="server">
                 </div>
                 <div class="form-group">
                         <label style="float:left;">Password</label>
                          <input type="password" class="form-control" id="Pass" placeholder="Password" runat="server">
                   </div>
<%--                 <div class="checkbox">
                          <label>
                             <input type="checkbox"> Remember me
                          </label>
                  </div>--%>
               <center>   <asp:Button ID="Login" runat="server" Text="Login" class="btn btn-default" OnClick="Login_Click" /></center>
              </form>
                      </div>
                   </div>
          </center>
               </div>
   
</asp:Content>
