<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaRequisiciones.aspx.cs" Inherits="Web.Requisicion.ListaRequisiciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<br />

	<asp:Button ID="btnCrearRequision" runat="server" Text="Crear requisición" Visible="false" OnClick="btnCrearRequision_Click" />

	<br /><br />

	<asp:GridView ID="gvRequisiciones" OnRowCommand="gvRequisiciones_RowCommand" runat="server" AutoGenerateColumns="False">
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="id" Visible="False" />
			<asp:BoundField DataField="MONTO" HeaderText="Monto" />
			<asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" />
			<asp:BoundField DataField="COMPRADOR" HeaderText="Comprador" />
			<asp:BoundField DataField="APROBADOR" HeaderText="Aprobador responsable" />
			<asp:BoundField DataField="FINANCIERO" HeaderText="Financiero responsable" />
			<asp:BoundField DataField="ESTADO" HeaderText="Estado" />
			<asp:TemplateField HeaderText="Opciones">
				<ItemTemplate>
					<asp:LinkButton ID="lblDetalle" runat="server" 
						Text="Detalle"
						CommandName="Details" 
						CommandArgument='<%#Bind("ID")%>'>
					</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>  

</asp:Content>
