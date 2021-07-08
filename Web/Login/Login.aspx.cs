using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.Login
{
	public partial class Login : System.Web.UI.Page
	{
		RequisionBD db = new RequisionBD();

		protected void Page_Load(object sender, EventArgs e)
		{
			List<ROL> roles = db.ROL.OrderBy(q => q.NOMBRE).ToList();
			foreach (ROL rol in roles)
				ddlRoles.Items.Insert(roles.IndexOf(rol), new ListItem(rol.NOMBRE, rol.ID.ToString()));
		}

		protected void btnIngresar_Click(object sender, EventArgs e)
		{
			//TODO validar usuario, contrasenna
			string usuario = txtUsuario.Text;
			string contrasenna = txtContrasenna.Text;

			USUARIO usuarioDB = db.USUARIO.Where(q => q.USUARIO1.Equals(usuario) && q.CONTRASENNA.Equals(contrasenna)).FirstOrDefault();

			if (usuarioDB != null)
			{
				//TODO redirigir a la pantalla del menu
			}
			else { 
				//TODO enviar alerta que diga usuario o contrasenna incorrecta
			}



		}
	}
}