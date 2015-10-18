<%@ Page Title="" Language="C#" MasterPageFile="~/Teachar.Master" AutoEventWireup="true" CodeBehind="THistory.aspx.cs" Inherits="ProComsys.WebForm24" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div style="margin-left:5%;">
         <br />
         <br />
         <br />
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
             
             <Columns>
                  <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
               </asp:TemplateField>
                  <asp:BoundField DataField="IDRequest" HeaderText="เลขที่คำร้องขอ" />
                 <asp:BoundField DataField="CPE" HeaderText="CPE." />
                  <asp:BoundField DataField="form" HeaderText="Form" />
                 <asp:BoundField DataField="PName" HeaderText="Project Name" />
              <%--    <asp:BoundField DataField="Role" HeaderText="Role" />--%>
                  <asp:BoundField DataField="Date" HeaderText="Date" />
                 <asp:BoundField DataField="status" HeaderText="Status" />
                 <asp:ButtonField ButtonType="Button" CommandName="Select" Text="click"  HeaderText="More.." />
             </Columns>
         </asp:GridView>
         <br />
      </div>
</asp:Content>
