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

    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:HyperLinkField Text="Detalles" />
        </Columns>
    </asp:GridView>

        <br />
        <br />
        <br />

    </div>


    </asp:Content>
