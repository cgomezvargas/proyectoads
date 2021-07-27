using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.Requisicion
{
	public partial class ListaRequisiciones : Page
	{
		RequisionBD db = new RequisionBD();

		protected void Page_Load(object sender, EventArgs e)
		{
			Title = "Lista de Requisiciones";

			if (!Page.IsPostBack)
			{
				int idUsuario = int.Parse(Request.Cookies["idUsuario"].Value);
				USUARIO usuario = db.USUARIO.Where(q => q.ID == idUsuario).FirstOrDefault();
				
				List<REQUISICION> requisionLista = null;
				switch (usuario.ROL.CODIGO) {
					case "COMPRADOR":
						btnCrearRequision.Visible = true;
						requisionLista = db.REQUISICION.Where(q => q.USUARIO1.ID == idUsuario).ToList();
						break;
					case "JEFE_APROBADOR":
						requisionLista = db.REQUISICION.Where(q => q.USUARIO.ID == idUsuario).ToList();
						break;
					default:
						requisionLista = db.REQUISICION.Where(q => q.USUARIO2.ID == idUsuario).ToList();
						break;
				}

				List<RequisicionDataSource> dataSource = new List<RequisicionDataSource>();
				foreach (REQUISICION req in requisionLista) {
					RequisicionDataSource requisicionData = new RequisicionDataSource();
					requisicionData.ID = req.ID;
					requisicionData.MONTO = req.MONTO;
					requisicionData.DESCRIPCION = req.DESCRIPCION;
					requisicionData.APROBADOR = req.USUARIO.NOMBRE;
					requisicionData.COMPRADOR = req.USUARIO1.NOMBRE;
					requisicionData.FINANCIERO = req.USUARIO2 != null ? req.USUARIO2.NOMBRE : "Pendiente Aprobación";

					string fechaEstado = "";
					switch (req.ESTADO.CODIGO) {
						case "REQUISION_CREADA":
							fechaEstado = req.FECHA_CREACION.ToString("dd/MM/yy hh:mm tt");
							break;
						case "REQUISION_RECHAZADA_APROBADOR":
							fechaEstado = req.FECHA_APROBADOR.Value.ToString("dd/MM/yy hh:mm tt");
							break;
						case "REQUISION_APROBADA_APROBADOR":
							fechaEstado = req.FECHA_APROBADOR.Value.ToString("dd/MM/yy hh:mm tt");
							break;
						case "REQUISION_RECHAZADA_FINANCIERO":
							fechaEstado = req.FECHA_FINANCIERO.Value.ToString("dd/MM/yy hh:mm tt");
							break;
						case "REQUISION_APROBADA_FINANCIERO":
							fechaEstado = req.FECHA_FINANCIERO.Value.ToString("dd/MM/yy hh:mm tt");
							break;
					}

					requisicionData.ESTADO = req.ESTADO.NOMBRE + " el " + fechaEstado;

					dataSource.Add(requisicionData);
				}

				gvRequisiciones.DataSource = dataSource;
				gvRequisiciones.DataBind();
			}
		}

		class RequisicionDataSource { 
			public int ID { get; set; }
			public decimal? MONTO { get; set; }
			public string DESCRIPCION { get; set; }
			public string COMPRADOR { get; set; }
			public string APROBADOR { get; set; }
			public string FINANCIERO { get; set; }
			public string ESTADO { get; set; }
		}
		protected void btnCrearRequision_Click(object sender, EventArgs e)
		{
			Response.Redirect("CrearRequisicion.aspx");
		}

		protected void gvRequisiciones_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Details")
			{
				string id = e.CommandArgument.ToString();
				Response.Redirect("Detalle.aspx?id=" + id);
			}
		}
	}

}