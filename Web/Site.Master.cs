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
				int idUsuario = int.Parse(Session["IdUsuario"].ToString());

				USUARIO userSession = db.USUARIO.Where(q => q.ID == idUsuario).FirstOrDefault();

				switch (userSession.ROL.CODIGO)
				{
					case "COMPRADOR":
						aRequisiciones.Visible = true;
						break;
					case "JEFE_APROBADOR":
						aUsuarios.Visible = true;

						break;
					default:
						break;

				}
			}
		}

		protected void lbCerrarSesion_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Response.Redirect("../Login/Login.aspx");
		}
	}
}