<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="Web.Usuarios.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


  
   <div style="display: flex; justify-content: center; align-items: center; padding:20px;">

        <asp:GridView  ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:HyperLinkField Text="Detalles" />
        </Columns>
    </asp:GridView>

   </div>

        <br />
        <br />
        <br />


    </asp:Content>
