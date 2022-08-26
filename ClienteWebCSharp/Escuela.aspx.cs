using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWebCSharp
{
    public partial class Escuela : System.Web.UI.Page
    {

        private static ServiceReference1.WebService1SoapClient servicio = new ServiceReference1.WebService1SoapClient();

        private void Listar() {
            gvEscuela.DataSource = servicio.Listar().Tables[0];
            gvEscuela.DataBind();

        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Listar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string codEscuela = txtCodEscuela.Text.Trim();
            string escuela = txtEscuela.Text.Trim();
            string facultad = txtFacultad.Text.Trim();
            bool rpta = servicio.Agregar(codEscuela, escuela, facultad);
            if (rpta)
            {
                Listar();
            }
            else Response.Write("<script>alert('No se agrego escuela');</script>");
        }

        protected void btnEliminar_Click(object sender, EventArgs e) {
            string codEscuela = txtCodEscuela.Text.Trim();
            bool rpta = servicio.Eliminar(codEscuela);
            if (rpta) {
                Listar();
            }
            else Response.Write("<script>alert('No se pudo eliminar escuela');</script>");
        }

        protected void btnActualizar_Click(object sender, EventArgs e) {
            string codEscuela = txtCodEscuela.Text.Trim();
            string escuela = txtEscuela.Text.Trim();
            string facultad = txtFacultad.Text.Trim();
            bool rpta = servicio.Actualizar(codEscuela, escuela, facultad);
            if (rpta)
            {
                Listar();
            }
            else Response.Write("<script>alert('No se pudo actualizar escuela');</script>");
        }

        protected void txtBuscar_Change(object senser, EventArgs e) {
            string texto = buscar.Text.Trim();
            gvEscuela.DataSource = servicio.Buscar(texto,criterio.Text.Trim());
            gvEscuela.DataBind();

        }

    }
}