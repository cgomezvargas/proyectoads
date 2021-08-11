<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearRequisicion.aspx.cs" Inherits="Web.Requisicion.CrearRequisicion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1 style="margin: 25px auto; text-align: center;">Crear requisición</h1>
	<table style="width: 40%; height: 100px; margin:80px auto; text-align:left;">
		<tr>
			<td>Monto</td>
			<td>
				<asp:TextBox CssClass="txtMonto" ID="txtMonto" runat="server" onkeypress="return isFloatNumber(this,event);" ></asp:TextBox>
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
