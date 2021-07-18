using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.Requisicion
{
	public partial class CrearRequisicion : Page
	{
		RequisionBD db = new RequisionBD();

		protected void Page_Load(object sender, EventArgs e)
		{

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

			db.REQUISICION.Add(nuevaRequision);
			db.SaveChanges();

			Response.Write("<script>alert('Requisición creada con éxito. No: '" + nuevaRequision.ID + ")</script>");
			Response.Redirect("ListaRequisiciones.aspx");
		}
	}
}