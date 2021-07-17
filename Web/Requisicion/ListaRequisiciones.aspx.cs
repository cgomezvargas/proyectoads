using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
			if (!Page.IsPostBack)
			{
				int idUsuario = int.Parse(Request.Cookies["idUsuario"].Value);
				USUARIO usuario = db.USUARIO.Where(q => q.ID == idUsuario).FirstOrDefault();
				
				List<REQUISICION> requisionLista = null;
				switch (usuario.ROL.CODIGO) {
					case "COMPRADOR":
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
					requisicionData.FECHA_APROBACION = req.FECHA_APROBADOR;
					requisicionData.FECHA_CREACION = req.FECHA_CREACION;
					requisicionData.FECHA_FINANCIERO = req.FECHA_FINANCIERO;
					requisicionData.ESTADO = req.ESTADO.NOMBRE;
					requisicionData.APROBADOR = req.USUARIO.NOMBRE;
					requisicionData.COMPRADOR = req.USUARIO1.NOMBRE;
					requisicionData.COMPRADOR = req.USUARIO1.NOMBRE;
					requisicionData.FINANCIERO = req.USUARIO2.NOMBRE;
					dataSource.Add(requisicionData);
				}

				gvRequisiciones.DataSource = dataSource;
				gvRequisiciones.DataBind();
				
			}
		}

		class RequisicionDataSource { 
			public int ID { get; set; }
			public decimal? MONTO { get; set; }
			public string COMPRADOR { get; set; }
			public string APROBADOR { get; set; }
			public string FINANCIERO { get; set; }
			public DateTime? FECHA_CREACION { get; set; }
			public DateTime? FECHA_APROBACION { get; set; }
			public DateTime? FECHA_FINANCIERO { get; set; }
			public string ESTADO { get; set; }
		}

		protected void btnCrearRequision_Click(object sender, EventArgs e)
		{
			Response.Redirect("CrearRequisicion.aspx");
		}
	}
}