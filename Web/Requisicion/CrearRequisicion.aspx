<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearRequisicion.aspx.cs" Inherits="Web.Requisicion.CrearRequisicion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Crear requisición</h1>
	<table style="width: 40%; height: 100px;">
		<tr>
			<td>Monto</td>
			<td>
				<asp:TextBox ID="txtMonto" runat="server" onkeypress="return isFloatNumber(this,event);"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<br />
				Detalle
			</td>
			<td>
				<br />
				<asp:TextBox ID="txtDescripcion" TextMode="MultiLine" runat="server" Width="275px"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<br />
				<asp:Button ID="btnCrear" runat="server" Text="Crear requisión" OnClick="btnCrear_Click" />
			</td>
		</tr>
	</table>
</asp:Content>
