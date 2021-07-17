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

				GridView1.DataSource = usuariosList;
				GridView1.DataBind();

				int i = 0;
	

			}
		}

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

		}
    }
}