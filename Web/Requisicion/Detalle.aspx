<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Web.Requisicion.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<br /><br />

	<table style="width:40%; margin:10px auto;">
		<tr>
			<td><b>Creada por: </b></td>
			<td>
				<asp:Label ID="lblComprador" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td><b>Estado actual: </b></td>
			<td>
				<asp:Label ID="lblEstado" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td><b>Número:</b></td>
			<td>
				<asp:Label ID="lblId" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td><b>Monto:</b></td>
			<td>
				<asp:Label ID="lblMonto" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td><b>Descripción:</b></td>
			<td>
				<asp:Label ID="lblDescripcion" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="btnAprobar" runat="server" Text="Aprobar" Visible="false" OnClick="btnAprobar_Click" />
			</td>
			<td>
				<asp:Button ID="btnRechazar" runat="server" Text="Rechazar" Visible="false" OnClick="btnRechazar_Click" />
			</td>
		</tr>
	</table>



</asp:Content>
