using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.Login
{
	public partial class Login : Page
	{
		RequisionBD db = new RequisionBD();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
				if (Session["idUsuario"] != null)
					Response.Redirect("../MenuPrincipal/MenuPrincipal.aspx");
		}

		protected void btnIngresar_Click(object sender, EventArgs e)
		{
			//TODO validar usuario, contrasenna
			string usuario = txtUsuario.Text;
			string contrasenna = Utilidades.Utilidades.CreateMD5(txtContrasenna.Text);

			USUARIO usuarioDB = db.USUARIO.Where(q => q.USUARIO1.Equals(usuario) && q.CONTRASENNA.Equals(contrasenna)).FirstOrDefault();

			if (usuarioDB != null)
			{
				Session["idUsuario"] = usuarioDB.ID;

				Response.Redirect("../MenuPrincipal/MenuPrincipal.aspx");
			}
			else { 
				//TODO enviar alerta que diga usuario o contrasenna incorrecta
			}

		}
	}
}