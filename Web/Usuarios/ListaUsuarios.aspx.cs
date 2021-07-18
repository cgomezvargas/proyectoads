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

				List<USUARIO> usuariosList = db.USUARIO.Where(q => q.ID_JEFE_APROBADOR == idUsuario).ToList();
			
				
				
				//List<USUARIO> UsuariosLista = null;
				List<ListaUsuariosDataSource> dataSource = new List<ListaUsuariosDataSource>();


				foreach (USUARIO uss in usuariosList)
				{
					ListaUsuariosDataSource UsuariosData = new ListaUsuariosDataSource();

					UsuariosData.NOMBRE = uss.NOMBRE;
					UsuariosData.CORREO = uss.CORREO;
					UsuariosData.USUARIO = uss.USUARIO1;
					UsuariosData.ID_JEFE_APROBADOR = uss.ID_JEFE_APROBADOR;
					dataSource.Add(UsuariosData);
				}

				GridView1.DataSource = dataSource;
				GridView1.DataBind();

				
				
				//int i = 0;
	

			}
		}

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

		}

		class ListaUsuariosDataSource
		{
			public int ID { get; set; }
			public String NOMBRE { get; set; }
			public string CORREO { get; set; }
			public string USUARIO { get; set; }
			public String CONTRASEÑA { get; set; }
			public int? ID_JEFE_APROBADOR { get; set; }
			
		}
	}
}