<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="Web.Usuarios.ListaUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	 <div class="btn">
        <asp:Button ID="btnCrearUsuario" runat="server" Text="Crear usuario" OnClick="btnCrearUsuario_Click" />
    </div>

	<div style="display: flex; justify-content: center; align-items: center; padding: 20px;">

	<asp:GridView ID="gvUsuarios" runat="server" OnRowCommand="gvUsuarios_RowCommand" AutoGenerateColumns="False">
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="id" Visible="False" />
			<asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
			<asp:BoundField DataField="CORREO" HeaderText="Correo" />
			<asp:BoundField DataField="USUARIO" HeaderText="Nombre de Usuario" />
			<asp:BoundField DataField="ROL" HeaderText="Rol" />
			<asp:BoundField DataField="JEFE" HeaderText="Jefe Aprobador" />
			<asp:BoundField DataField="ESTADO" HeaderText="Estado" />
			<asp:TemplateField HeaderText="Opciones">
				<ItemTemplate>
					<asp:LinkButton ID="LinkButton1" runat="server"
						Text="Editar"
						CommandName="Editar"
						CommandArgument='<%#Bind("ID")%>'>
					</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>

	</div>

	<br />
	<br />
	<br />

</asp:Content>
