using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.Requisicion
{
	public partial class Detalle : Page
	{
		RequisionBD db = new RequisionBD();

		protected void Page_Load(object sender, EventArgs e)
		{
			Title = "Detalle";
			if (!Page.IsPostBack)
			{
				int idUsuario = int.Parse(Request.Cookies["idUsuario"].Value);
				USUARIO usuario = db.USUARIO.Where(q => q.ID == idUsuario).FirstOrDefault();

				string id = Request.QueryString["id"];
				if (id == null) {
					Response.Write("<script>alert('Requisición incorrecta')</script>");
					Response.Redirect("ListaRequisiciones.aspx");
				}
				int idInt = int.Parse(id);

				REQUISICION req = db.REQUISICION.Where(q => q.ID == idInt).SingleOrDefault();
				if (req != null)
				{
					lblId.Text = req.ID.ToString();
					lblDescripcion.Text = req.DESCRIPCION.ToString();
					lblMonto.Text = req.MONTO.ToString();
					lblComprador.Text = req.USUARIO1.NOMBRE;
					lblEstado.Text = req.ESTADO.NOMBRE;

					switch (usuario.ROL.CODIGO) {
						case "COMPRADOR":
							break;
						case "JEFE_APROBADOR":

							if (req.ESTADO.CODIGO == "REQUISION_CREADA") {
								btnAprobar.Visible = true;
								btnRechazar.Visible = true;
							}

							break;
						default :

							if (req.ESTADO.CODIGO == "REQUISION_APROBADA_APROBADOR")
							{
								btnAprobar.Visible = true;
								btnRechazar.Visible = true;
							}

							break;
					}

				}
				else {
					Response.Write("<script>alert('Requisición incorrecta')</script>");
					Response.Redirect("ListaRequisiciones.aspx");

				}
			}
		}

		protected void btnAprobar_Click(object sender, EventArgs e)
		{
			int idUsuario = int.Parse(Request.Cookies["idUsuario"].Value);
			USUARIO usuario = db.USUARIO.Where(q => q.ID == idUsuario).FirstOrDefault();
			int idInt = int.Parse(Request.QueryString["id"]);

			if (usuario.ROL.CODIGO.Equals("JEFE_APROBADOR"))
			{
				REQUISICION req = db.REQUISICION.Where(q => q.ID == idInt).SingleOrDefault();
				req.FECHA_APROBADOR = DateTime.Now;
				req.ESTADO = db.ESTADO.Where(q => q.CODIGO.Equals("REQUISION_APROBADA_APROBADOR")).FirstOrDefault();
				db.SaveChanges();
			}
			else if (usuario.ROL.CODIGO.StartsWith("APROBADOR_FINANCIERO")) {
				REQUISICION req = db.REQUISICION.Where(q => q.ID == idInt).SingleOrDefault();
				req.FECHA_FINANCIERO = DateTime.Now;
				req.ESTADO = db.ESTADO.Where(q => q.CODIGO.Equals("REQUISION_APROBADA_FINANCIERO")).FirstOrDefault();
				db.SaveChanges();
			}

			Utilidades.Notificaciones.EnviarNotificacion(idInt);
			Response.Redirect("ListaRequisiciones.aspx");
		}

		protected void btnRechazar_Click(object sender, EventArgs e)
		{
			int idUsuario = int.Parse(Request.Cookies["idUsuario"].Value);
			USUARIO usuario = db.USUARIO.Where(q => q.ID == idUsuario).FirstOrDefault();
			int idInt = int.Parse(Request.QueryString["id"]);

			if (usuario.ROL.CODIGO.Equals("JEFE_APROBADOR"))
			{
				REQUISICION req = db.REQUISICION.Where(q => q.ID == idInt).SingleOrDefault();
				req.FECHA_APROBADOR = DateTime.Now;
				req.ESTADO = db.ESTADO.Where(q => q.CODIGO.Equals("REQUISION_RECHAZADA_APROBADOR")).FirstOrDefault();
				db.SaveChanges();
			}
			else if (usuario.ROL.CODIGO.StartsWith("APROBADOR_FINANCIERO"))
			{
				REQUISICION req = db.REQUISICION.Where(q => q.ID == idInt).SingleOrDefault();
				req.FECHA_FINANCIERO = DateTime.Now;
				req.ESTADO = db.ESTADO.Where(q => q.CODIGO.Equals("REQUISION_RECHAZADA_FINANCIERO")).FirstOrDefault();
				db.SaveChanges();
			}

			Utilidades.Notificaciones.EnviarNotificacion(idInt);

			Response.Redirect("ListaRequisiciones.aspx");
		}
	}
}