using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;
using Web.Utilidades;

namespace Web.Requisicion
{
	public partial class CrearRequisicion : Page
	{
		RequisionBD db = new RequisionBD();

		protected void Page_Load(object sender, EventArgs e)
		{
			Title = "Crear requisición";
		}

		protected void btnCrear_Click(object sender, EventArgs e)
		{
			int idUsuario = int.Parse(Request.Cookies["idUsuario"].Value);

			USUARIO userSession = db.USUARIO.Where(q => q.ID == idUsuario).FirstOrDefault();

			REQUISICION nuevaRequision = new REQUISICION();
			nuevaRequision.MONTO = decimal.Parse(txtMonto.Text);
			nuevaRequision.DESCRIPCION = txtDescripcion.Text;
			nuevaRequision.FECHA_CREACION = DateTime.Now;
			nuevaRequision.USUARIO1 = userSession;
			nuevaRequision.USUARIO = userSession.USUARIO2;
			nuevaRequision.ESTADO = db.ESTADO.Where(q => q.CODIGO.Equals("REQUISION_CREADA")).FirstOrDefault();

			#region Determina Jefe Financiero basado en monto de requisicion
			decimal monto = decimal.Parse(txtMonto.Text);
			ROL rolFinanciero = db.ROL.Where(q => q.CODIGO.StartsWith("APROBADOR_FINANCIERO") && q.LIMITE_APROBACION >= monto).OrderBy(q => q.LIMITE_APROBACION).Take(1).FirstOrDefault();

			USUARIO uusuarioFinanciero = db.USUARIO.Where(q => q.ID_ROL == rolFinanciero.ID && q.ID_JEFE_APROBADOR == userSession.USUARIO2.ID).FirstOrDefault();
			nuevaRequision.USUARIO2 = uusuarioFinanciero != null ? uusuarioFinanciero : userSession.USUARIO2;
			#endregion

			db.REQUISICION.Add(nuevaRequision);
			db.SaveChanges();

			Notificaciones.EnviarNotificacion(nuevaRequision.ID);

			Response.Write("<script>alert('Requisición creada con éxito. No: " + nuevaRequision.ID + "')</script>");
			Response.Redirect("ListaRequisiciones.aspx");
		}
	}
}