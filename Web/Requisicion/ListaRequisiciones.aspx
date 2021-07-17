<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaRequisiciones.aspx.cs" Inherits="Web.Requisicion.ListaRequisiciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<br />

	<asp:Button ID="btnCrearRequision" runat="server" Text="Crear requisición" />

	<br /><br />

	<asp:GridView ID="gvRequsiciones" runat="server" AutoGenerateColumns="False">
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="id" Visible="False" />
			<asp:BoundField DataField="MONTO" HeaderText="Monto" />
			<asp:BoundField DataField="COMPRADOR" HeaderText="Comprador" />
			<asp:BoundField DataField="APROBADOR" HeaderText="Aprobador" />
			<asp:BoundField DataField="FINANCIERO" HeaderText="Financiero" />
			<asp:BoundField DataField="FECHA_CREACION" HeaderText="Fecha Creación" />
			<asp:BoundField DataField="FECHA_APROBACION" HeaderText="Fecha Aprobación" />
			<asp:BoundField DataField="FECHA_FINANCIERO" HeaderText="Fecha Financiero" />
			<asp:BoundField DataField="ESTADO" HeaderText="Estado" />
			<asp:HyperLinkField Text="Detalles" />
		</Columns>
	</asp:GridView>  

</asp:Content>
