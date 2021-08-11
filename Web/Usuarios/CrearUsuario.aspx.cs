using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.Usuarios
{
	public partial class CrearUsuario : System.Web.UI.Page
	{
		RequisionBD db = new RequisionBD();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int idUsuario = int.Parse(Request.Cookies["idUsuario"].Value);

				USUARIO usuario = db.USUARIO.Where(q => q.ID == idUsuario).FirstOrDefault();

				if (usuario.ROL.CODIGO.Equals("ADMIN") || usuario.ROL.CODIGO.Equals("JEFE_APROBADOR")) {
					List<ROL> roles = new List<ROL>();
					roles.Add(new ROL() { ID = 0, NOMBRE = "Seleccione un rol", CODIGO = "SELECCIONE" });

					if (usuario.ROL.CODIGO.Equals("ADMIN"))
						roles.AddRange(db.ROL.ToList());
					else
						roles.AddRange(db.ROL.Where(q => q.CODIGO.StartsWith("APROBADOR_FINANCIERO")).ToList());
					
					trJefeAprobador.Visible = false;

					ddlRol.DataSource = roles;
					ddlRol.DataTextField = "NOMBRE";
					ddlRol.DataValueField = "CODIGO";
					ddlRol.DataBind();
				}
				else
					Response.Redirect("ListaUsuarios.aspx");

				string id = Request.QueryString["id"];
				if (!string.IsNullOrEmpty(id)) {
					int idInt = int.Parse(id);
					USUARIO usuarioEditar = db.USUARIO.Where(q => q.ID == idInt).FirstOrDefault();

					txtNombre.Text = usuarioEditar.NOMBRE;
					txtCorreo.Text = usuarioEditar.CORREO;
					txtNombreUsuario.Text = usuarioEditar.NOMBRE_USUARIO;
					ddlRol.SelectedValue = usuarioEditar.ROL.CODIGO;
					cbActivo.Checked = usuarioEditar.ESTADO;

					if ((ddlRol.SelectedValue.Equals("COMPRADOR") || ddlRol.SelectedValue.StartsWith("APROBADOR_FINANCIERO")) && usuario.ROL.CODIGO.Equals("ADMIN"))
					{
						ddlJefeAprobador.DataSource = db.USUARIO.Where(q => q.ROL.CODIGO.Equals("JEFE_APROBADOR")).ToList();

						ddlJefeAprobador.DataTextField = "NOMBRE";
						ddlJefeAprobador.DataValueField = "ID";
						ddlJefeAprobador.DataBind();

						trJefeAprobador.Visible = true;

						ddlJefeAprobador.SelectedValue = usuarioEditar.ID_JEFE_APROBADOR.ToString();
					}

				}
			}
		}

		protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
		{
			int idUsuario = int.Parse(Request.Cookies["idUsuario"].Value);

			USUARIO usuario = db.USUARIO.Where(q => q.ID == idUsuario).FirstOrDefault();

			if ((ddlRol.SelectedValue.Equals("COMPRADOR") || ddlRol.SelectedValue.StartsWith("APROBADOR_FINANCIERO")) && usuario.ROL.CODIGO.Equals("ADMIN")) {
				ddlJefeAprobador.DataSource = db.USUARIO.Where(q => q.ROL.CODIGO.Equals("JEFE_APROBADOR")).ToList();
				
				ddlJefeAprobador.DataTextField = "NOMBRE";
				ddlJefeAprobador.DataValueField = "ID";
				ddlJefeAprobador.DataBind();

				trJefeAprobador.Visible = true;
			}
			else {
				trJefeAprobador.Visible = false;
			}
		}

		protected void btnCrear_Click(object sender, EventArgs e)
		{
			string id = Request.QueryString["id"];
			int idInt = 0;
			bool editMode = id != null;

			if (id != null)
				idInt = int.Parse(id);

			int idUsuario = int.Parse(Request.Cookies["idUsuario"].Value);

			USUARIO usuario = db.USUARIO.Where(q => q.ID == idUsuario).FirstOrDefault();

			if (string.IsNullOrEmpty(txtNombre.Text))
			{
				txtNombre.Focus();
				Response.Write("<script>alert('El nombre es requerido.')</script>");
			}
			else if (string.IsNullOrEmpty(txtCorreo.Text))
			{
				txtCorreo.Focus();
				Response.Write("<script>alert('El Correo es requerido.')</script>");
			}
			else if (!IsValidEmailAddress(txtCorreo.Text))
			{
				txtCorreo.Focus();
				Response.Write("<script>alert('Formato incorrecto de correo electronico.')</script>");
			}
			else if (!editMode && db.USUARIO.Where(q => q.CORREO.ToLower().Equals(txtCorreo.Text.ToLower())).FirstOrDefault() != null)
			{
				txtCorreo.Focus();
				Response.Write("<script>alert('El correo electronico ya se encuentra registrado.')</script>");
			}
			else if (editMode && db.USUARIO.Where(q => q.CORREO.ToLower().Equals(txtCorreo.Text.ToLower()) && q.ID != idInt).FirstOrDefault() != null)
			{
				txtCorreo.Focus();
				Response.Write("<script>alert('El correo electronico ya se encuentra registrado.')</script>");
			}
			else if (string.IsNullOrEmpty(txtNombreUsuario.Text))
			{
				txtNombreUsuario.Focus();
				Response.Write("<script>alert('Nombre de usuario es requerido.')</script>");
			}
			else if (!editMode && db.USUARIO.Where(q => q.NOMBRE_USUARIO.ToLower().Equals(txtNombreUsuario.Text.ToLower())).FirstOrDefault() != null)
			{
				txtNombreUsuario.Focus();
				Response.Write("<script>alert('Nombre de usuario ya se encuentra registrado.')</script>");
			}
			else if (editMode && db.USUARIO.Where(q => q.NOMBRE_USUARIO.ToLower().Equals(txtNombreUsuario.Text.ToLower()) && q.ID != idInt).FirstOrDefault() != null)
			{
				txtNombreUsuario.Focus();
				Response.Write("<script>alert('Nombre de usuario ya se encuentra registrado.')</script>");
			}
			else if (!editMode && string.IsNullOrEmpty(txtContrasenna.Text))
			{
				txtContrasenna.Focus();
				Response.Write("<script>alert('La contrasena es requerida.')</script>");
			}
			else if (ddlRol.SelectedValue.Equals("SELECCIONE"))
			{
				ddlRol.Focus();
				Response.Write("<script>alert('Seleccione el rol, es requerido.')</script>");
			}
			else
			{
				USUARIO usuarioNuevo = editMode ? db.USUARIO.Where(q => q.ID == idInt).FirstOrDefault() : new USUARIO();

				if (!editMode)
					db.USUARIO.Add(usuarioNuevo);

				usuarioNuevo.NOMBRE = txtNombre.Text;
				usuarioNuevo.CORREO = txtCorreo.Text;
				usuarioNuevo.NOMBRE_USUARIO = txtNombreUsuario.Text;
				usuarioNuevo.ESTADO = cbActivo.Checked;

				if (!string.IsNullOrEmpty(txtContrasenna.Text))
					usuarioNuevo.CONTRASENNA = Utilidades.Utilidades.CreateMD5(txtContrasenna.Text);
				usuarioNuevo.ROL = db.ROL.Where(q => q.CODIGO.Equals(ddlRol.SelectedValue)).FirstOrDefault();

				if (ddlRol.SelectedValue.Equals("COMPRADOR") || ddlRol.SelectedValue.StartsWith("APROBADOR_FINANCIERO"))
					if (usuario.ROL.CODIGO.Equals("ADMIN"))
						usuarioNuevo.ID_JEFE_APROBADOR = int.Parse(ddlJefeAprobador.SelectedValue);
					else

						usuarioNuevo.ID_JEFE_APROBADOR = idUsuario;

				db.SaveChanges();
				Response.Write("<script>alert('Usuario guardado con éxito.')</script>");
				Response.Redirect("ListaUsuarios.aspx");
			}


		}

		public bool IsValidEmailAddress(string email)
		{
			try
			{
				var emailChecked = new System.Net.Mail.MailAddress(email);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}