<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="Web.Usuarios.CrearUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1 style="margin: 25px auto; text-align: center;">Crear usuario</h1>
	<table style="width: 50%; height: 300px; margin: 50px auto; text-align: left;">
		<tr style="height: 40px;">
			<td style="width: 200px;">Nombre:</td>
			<td>
				<asp:TextBox CssClass="txtMonto" ID="txtNombre" runat="server" Width="100%"></asp:TextBox>
			</td>
		</tr>
		<tr style="height: 40px;">
			<td>Correo:</td>
			<td>
				<asp:TextBox CssClass="txtMonto" ID="txtCorreo" runat="server" Width="100%"></asp:TextBox>
			</td>
		</tr>
		<tr style="height: 40px;">
			<td>Nombre de usuario:</td>
			<td>
				<asp:TextBox CssClass="txtMonto" ID="txtNombreUsuario" Width="100%" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr style="height: 40px;">
			<td>Contrase&ntilde;a:</td>
			<td>
				<asp:TextBox CssClass="txtMonto" ID="txtContrasenna" runat="server" Width="100%"></asp:TextBox>
			</td>
		</tr>
		<tr style="height: 40px;">
			<td>Estado:</td>
			<td>
				<asp:CheckBox ID="cbActivo" Checked="true" Text="Activo" runat="server" />
			</td>
		</tr>
		<tr style="height: 40px;">
			<td>Rol</td>
			<td>
				<asp:DropDownList  CssClass="txtMonto"  ID="ddlRol" Width="100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged"></asp:DropDownList>
			</td>
		</tr>
		<tr id="trJefeAprobador" runat="server" style="height: 40px;">
			<td>Jefe Aprobador</td>
			<td>
				<asp:DropDownList  CssClass="txtMonto"  ID="ddlJefeAprobador" Width="100%" runat="server"></asp:DropDownList>
			</td>
		</tr>
		<tr style="align-content: center;">
			<td colspan="2" style="align-content: center;">
				<br />
				<asp:Button ID="btnCrear" runat="server" Text="Guardar usuario" OnClick="btnCrear_Click" />
			</td>
		</tr>
	</table>
</asp:Content>
