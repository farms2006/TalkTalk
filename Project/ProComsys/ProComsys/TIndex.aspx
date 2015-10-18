<%@ Page Title="" Language="C#" MasterPageFile="~/Teachar.Master" AutoEventWireup="true" CodeBehind="TIndex.aspx.cs" Inherits="ProComsys.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
        .auto-style2 {
            font-size: large;
        }
        .auto-style3 {
            text-decoration: underline;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="margin-left:5%;"><br>
         <strong><span class="auto-style2">
         <br class="auto-style1"></span><span class="auto-style1"><span class="auto-style2">โครงงานที่รับผิดชอบ</span></span></strong><br />
         <br>
       <div >
           <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
           <br>
           <br />
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
               <Columns>
                    <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
               </asp:TemplateField>
                   <asp:BoundField DataField="IDPro" HeaderText="เลขที่โครงงาน" NullDisplayText="-" />
                   <asp:BoundField DataField="PTName" HeaderText="ชื่อโครงงาน(ภาษาไทย)" NullDisplayText="-" />
                   <asp:BoundField DataField="PEName" HeaderText="ชื่อโครงงาน(ภาษาอังกฤษ)" NullDisplayText="-" />
                    <asp:ButtonField CommandName="select" HeaderText="เพื่มเติม" Text="รายละเอียด" />
               </Columns>
           </asp:GridView>

           <br />
           <br />
           <span class="auto-style3">รายละเอียดโครงงาน<br />
           </span>

           <br />
           <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
               <Columns>
                   <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
               </asp:TemplateField>
                   <asp:BoundField DataField="IDRe" HeaderText="เลขที่คำร้องขอ" NullDisplayText="-" />
                   <asp:BoundField DataField="form" HeaderText="แบบฟอร์ม" NullDisplayText="-" />
                   <asp:BoundField DataField="RequestDate" HeaderText="วันที่ส่ง" NullDisplayText="-" />
                   <asp:BoundField DataField="AcceptDate" HeaderText="วันที่ตอบรับ" NullDisplayText="-" />
                   <asp:BoundField DataField="status" HeaderText="สถานะ" NullDisplayText="-" />
               </Columns>
           </asp:GridView>
           <br />

           </div>
          

      </div>
</asp:Content>
