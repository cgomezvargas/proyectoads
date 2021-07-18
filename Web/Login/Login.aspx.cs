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
				if (Request.Cookies["idUsuario"] != null && Request.Cookies["idUsuario"].Value != null)
					Response.Redirect("../MenuPrincipal/MenuPrincipal.aspx");
		}

		protected void btnIngresar_Click(object sender, EventArgs e)
		{
			//TODO validar usuario, contrasenna
			string usuario = txtUsuario.Text;
			string contrasenna = Utilidades.Utilidades.CreateMD5(txtContrasenna.Text);

			USUARIO usuarioDB = db.USUARIO.Where(q => q.NOMBRE_USUARIO.Equals(usuario) && q.CONTRASENNA.Equals(contrasenna)).FirstOrDefault();

			if (usuarioDB != null)
			{
				Response.Cookies["idUsuario"].Value = usuarioDB.ID.ToString();

				Response.Redirect("../MenuPrincipal/MenuPrincipal.aspx");
			}
			else { 
				//TODO enviar alerta que diga usuario o contrasenna incorrecta
			}

		}
	}
}