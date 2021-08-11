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
					Response.Redirect("../Requisicion/ListaRequisiciones.aspx");
		}

		protected void btnIngresar_Click(object sender, EventArgs e)
		{

			if (string.IsNullOrEmpty(txtUsuario.Text))
			{
				txtUsuario.Focus();
				Response.Write("<script>alert('Por favor ingrese el nombre de usuario.')</script>");
			}
			else if (string.IsNullOrEmpty(txtContrasenna.Text))
			{
				txtContrasenna.Focus();
				Response.Write("<script>alert('Por favor ingrese la contrasena.')</script>");
			}
			else
			{
				string usuario = txtUsuario.Text;
				string contrasenna = Utilidades.Utilidades.CreateMD5(txtContrasenna.Text);

				USUARIO usuarioDB = db.USUARIO.Where(q => q.NOMBRE_USUARIO.Equals(usuario) && q.CONTRASENNA.Equals(contrasenna)).FirstOrDefault();

				if (usuarioDB != null)
				{
					if (usuarioDB.ESTADO)
					{
						Response.Cookies["idUsuario"].Value = usuarioDB.ID.ToString();

						Response.Redirect("../Requisicion/ListaRequisiciones.aspx");
					}
					else
						Response.Write("<script>alert('Usuario se encuentra inactivo.')</script>");

				}
				else
					Response.Write("<script>alert('Usuario o contrasena incorrecta.')</script>");
			}
		}
	}
}