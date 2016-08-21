<%@ Page Language="C#" AutoEventWireup="true"  CodeFile ="add_product.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="add_product" %>

<asp:Content runat="server" ContentPlaceHolderID ="ContentPlaceHolder1">
    <p>Hii</p>
    
     <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Product" />
           
           <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" CellPadding="4"
               DataKeyNames="productId" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="GridView1_RowCancelingEdit"
               OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
               <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"  />
               <Columns>
                   <asp:CommandField HeaderText="Edit-Update" ShowEditButton="True" />
                  
                   <asp:BoundField DataField="name" HeaderText="Name"  />
                   <asp:BoundField DataField="colors" HeaderText="colors"  />
                   <asp:BoundField DataField="description" HeaderText="Desc" />
                   <asp:BoundField DataField="price" HeaderText="Price" />
                   <asp:TemplateField HeaderText="Sample Dropdown">
                <ItemTemplate>
<asp:DropDownList Width="50" runat="server" 
   id="DropDownList1" AutoPostBack="true" 
   >
</asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
                   
                   <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />

               </Columns>
               <RowStyle BackColor="#E3EAEB" />
               <EditRowStyle BackColor="#7C6F57" />
               <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
               <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
               <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
               <AlternatingRowStyle BackColor="White" />
          </asp:GridView>


</asp:Content>