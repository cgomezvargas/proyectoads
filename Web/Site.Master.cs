using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web
{
	public partial class SiteMaster : MasterPage
	{
		RequisionBD db = new RequisionBD();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int idUsuario = int.Parse(Request.Cookies["idUsuario"].Value);

				USUARIO userSession = db.USUARIO.Where(q => q.ID == idUsuario).FirstOrDefault();
			
				switch (userSession.ROL.CODIGO)
				{
					case "COMPRADOR":
						aRequisiciones.Visible = true;
						break;
					case "JEFE_APROBADOR":
						aUsuarios.Visible = true;
						aRequisiciones.Visible = true;
						break;
					default:
						aRequisiciones.Visible = true;

						break;

				}

				lblHome.Text = String.Format("Usuario: {0}<br/>Rol: {1}", userSession.NOMBRE, userSession.ROL.NOMBRE);

			}
		}

		protected void lbCerrarSesion_Click(object sender, EventArgs e)
		{
			Response.Cookies.Remove("idUsuario");
			var aCookie = new HttpCookie("idUsuario") { Expires = DateTime.Now.AddDays(-1) };
			Response.Cookies.Add(aCookie);

			Response.Redirect("../Login/Login.aspx");
			
		}
	}
}