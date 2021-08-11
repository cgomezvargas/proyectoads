using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.Usuarios
{
	public partial class ListaUsuarios : System.Web.UI.Page
	{
		RequisionBD db = new RequisionBD();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int idUsuario = int.Parse(Request.Cookies["idUsuario"].Value);

				USUARIO usuario = db.USUARIO.Where(q => q.ID == idUsuario).FirstOrDefault();

				btnCrearUsuario.Visible = usuario.ROL.CODIGO.Equals("ADMIN") || usuario.ROL.CODIGO.Equals("JEFE_APROBADOR");

				List<USUARIO> usuariosList = null;

				if (usuario.ROL.CODIGO.Equals("ADMIN"))
					usuariosList = db.USUARIO.OrderBy(q => q.ROL.NOMBRE).ThenBy(q => q.NOMBRE).ToList();
				else
					usuariosList = db.USUARIO.Where(q => q.ID_JEFE_APROBADOR == idUsuario && q.ROL.CODIGO.StartsWith("APROBADOR_FINANCIERO")).OrderBy(q => q.ROL.NOMBRE).ThenBy(q => q.NOMBRE).ToList();
			
				List<ListaUsuariosDataSource> dataSource = new List<ListaUsuariosDataSource>();

				foreach (USUARIO uss in usuariosList)
				{
					ListaUsuariosDataSource usuarioDataSource = new ListaUsuariosDataSource();

					usuarioDataSource.ID = uss.ID;
					usuarioDataSource.NOMBRE = uss.NOMBRE;
					usuarioDataSource.CORREO = uss.CORREO;
					usuarioDataSource.USUARIO = uss.NOMBRE_USUARIO;
					usuarioDataSource.ROL = uss.ROL.NOMBRE;
					usuarioDataSource.ESTADO = uss.ESTADO ? "Activo" : "Inactivo";

					if (uss.ROL.CODIGO.Equals("COMPRADOR") || uss.ROL.CODIGO.StartsWith("APROBADOR_FINANCIERO"))
						usuarioDataSource.JEFE = db.USUARIO.Where(q => q.ID == uss.ID_JEFE_APROBADOR).FirstOrDefault().NOMBRE;
					else
						usuarioDataSource.JEFE = "No aplica";

					dataSource.Add(usuarioDataSource);
				}

				gvUsuarios.DataSource = dataSource;
				gvUsuarios.DataBind();
			}
		}

		class ListaUsuariosDataSource
		{
			public int ID { get; set; }
			public String NOMBRE { get; set; }
			public string CORREO { get; set; }
			public string USUARIO { get; set; }
			public string ROL { get; set; }
			public string JEFE { get; set; }
			public string ESTADO { get; set; }

		}

		protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			string id = e.CommandArgument.ToString();

			if (e.CommandName == "Editar")
				Response.Redirect("CrearUsuario.aspx?id=" + id);

		}

		protected void btnCrearUsuario_Click(object sender, EventArgs e)
		{
			Response.Redirect("CrearUsuario.aspx");
		}
	}
}