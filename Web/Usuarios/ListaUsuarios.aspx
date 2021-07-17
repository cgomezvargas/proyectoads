<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="Web.Usuarios.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <style type="text/css">

        .table {
            margin:85px auto;
        }


        .button {

            margin:20px;

        }


    </style>

    <div class="table">

    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>

        <br />
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

    </div>


    <asp:Button CssClass="button" ID="Button1" runat="server" Text="Agregar" />

    <asp:Button CssClass="button" ID="Button2" runat="server" Text="Actualizar" />

    <asp:Button CssClass="button" ID="Button3" runat="server" Text="Eliminar" />

</asp:Content>
